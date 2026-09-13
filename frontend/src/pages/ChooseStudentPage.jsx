import { useState, useEffect } from 'react'
import { useNavigate, Link } from 'react-router-dom'
import { Loader2, RefreshCw, ArrowLeft, Search, Sparkles } from 'lucide-react'
import Layout from '../components/Layout'
import StepIndicator from '../features/student-entry/components/StepIndicator'
import StudentCard from '../features/student-entry/components/StudentCard'
import { useStudents } from '../features/student-entry/hooks/useStudents'
import { useStudentLogin } from '../features/student-entry/hooks/useStudentLogin'
import { useStudentEntryStore } from '../features/student-entry/store/useStudentEntryStore'

/** Extract a friendly message from an Axios error (backend sends { error: "..." }). */
function getFriendlyError(err) {
  return err?.response?.data?.error || 'Something went wrong. Please try again!'
}

export default function ChooseStudentPage() {
  const navigate = useNavigate()
  const selectedClass = useStudentEntryStore((s) => s.selectedClass)

  // Guard: redirect if no class selected
  useEffect(() => {
    if (!selectedClass) navigate('/student-entry', { replace: true })
  }, [selectedClass, navigate])

  const classId = selectedClass?.classId
  const { data: students, isLoading, isError, refetch } = useStudents(classId)
  const loginMutation = useStudentLogin()

  const [selectedId, setSelectedId] = useState(null)

  if (!selectedClass) return null

  const selectedStudent = students?.find((s) => s.studentId === selectedId)

  function handleLogin() {
    if (!selectedStudent) return
    loginMutation.mutate({
      classId: selectedClass.classId,
      studentId: selectedStudent.studentId,
    })
  }

  return (
    <Layout>
      <div className="mx-auto max-w-5xl px-4 sm:px-6 pb-10">
        <StepIndicator currentStep={2} />

        {/* Class context badge */}
        <div className="flex justify-center pt-1 pb-2">
          <span className="inline-flex items-center gap-1.5 rounded-full bg-brand-blue/10 px-4 py-1.5 text-xs font-bold text-brand-blue">
            <Sparkles size={14} />
            Class {selectedClass.className}
            <Link
              to="/student-entry"
              className="ml-2 underline text-brand-blue/70 hover:text-brand-blue transition-colors"
            >
              Change
            </Link>
          </span>
        </div>

        {/* Page Header */}
        <div className="pt-2 pb-6 text-center">
          <h1 className="text-2xl sm:text-3xl font-extrabold text-brand-navy tracking-tight m-0">
            Who are you today?{' '}
            <span aria-hidden="true">🎭🎨</span>
          </h1>
          <p className="mt-1 text-base font-bold text-brand-blue m-0" dir="rtl">
            من أنت اليوم؟ 🌟
          </p>
          <p className="mt-2 text-sm text-text-secondary max-w-lg mx-auto leading-relaxed">
            Tap your name to load your saved stars and jump straight into the adventure!
          </p>
        </div>

        {/* Loading */}
        {isLoading && (
          <div className="flex flex-col items-center justify-center py-20 gap-3">
            <Loader2 size={32} className="text-brand-blue animate-spin" />
            <p className="text-sm text-text-muted font-medium">Finding students…</p>
          </div>
        )}

        {/* Error */}
        {isError && (
          <div className="flex flex-col items-center justify-center py-16 gap-4">
            <div className="text-4xl" aria-hidden="true">😥</div>
            <p className="text-brand-pink font-semibold text-lg m-0">Oops! Something went wrong</p>
            <p className="text-text-secondary text-sm m-0">We couldn&apos;t load the students. Let&apos;s try again!</p>
            <button
              type="button"
              onClick={() => refetch()}
              className="inline-flex items-center gap-2 rounded-full bg-brand-blue px-5 py-2.5 text-sm font-bold text-white shadow-soft transition-all hover:brightness-110 hover:shadow-lg cursor-pointer"
            >
              <RefreshCw size={16} />
              Try Again
            </button>
          </div>
        )}

        {/* Empty — no students */}
        {!isLoading && !isError && students?.length === 0 && (
          <div className="text-center py-16">
            <div className="text-4xl mb-3" aria-hidden="true">👤</div>
            <p className="text-brand-navy font-semibold text-lg mb-2 m-0">No students in this class yet!</p>
            <p className="text-text-secondary text-sm mb-4 m-0">Be the first explorer to join this class!</p>
            <button
              type="button"
              onClick={() => navigate('/student-entry/create-student')}
              className="inline-flex items-center gap-2 rounded-full bg-brand-pink px-6 py-3 text-sm font-bold text-white shadow-card transition-all hover:brightness-110 hover:shadow-lg cursor-pointer"
            >
              Create My Profile 🚀
            </button>
          </div>
        )}

        {/* Student Grid */}
        {!isLoading && !isError && students && students.length > 0 && (
          <>
            <div className="grid grid-cols-2 sm:grid-cols-3 lg:grid-cols-4 gap-4 sm:gap-5">
              {students.map((student) => (
                <StudentCard
                  key={student.studentId}
                  student={student}
                  isSelected={selectedId === student.studentId}
                  onSelect={() => setSelectedId(student.studentId)}
                />
              ))}
            </div>

            {/* Fox mascot welcome-back message */}
            {selectedStudent && (
              <div className="mt-6 flex items-center gap-3 rounded-2xl border border-brand-yellow/30 bg-brand-yellow/10 p-4 shadow-soft animate-[fadeIn_0.3s_ease-out]">
                <span className="text-3xl shrink-0" aria-hidden="true">🦊</span>
                <div className="min-w-0 flex-1">
                  <p className="text-sm font-bold text-brand-navy m-0">
                    Fox Rami: &ldquo;I remember you, {selectedStudent.studentName}! Let&apos;s play 🎮&rdquo;
                  </p>
                  <p className="text-xs text-text-secondary mt-0.5 m-0" dir="rtl">
                    أنا أتذكرك! هيا نلعب ونتعلم معاً 🌟
                  </p>
                </div>
                <button
                  type="button"
                  onClick={handleLogin}
                  disabled={loginMutation.isPending}
                  className="shrink-0 inline-flex items-center gap-1.5 rounded-full bg-brand-blue px-4 py-2 text-xs font-bold text-white shadow-soft transition-all hover:brightness-110 cursor-pointer disabled:opacity-60 disabled:cursor-not-allowed"
                >
                  {loginMutation.isPending ? (
                    <Loader2 size={14} className="animate-spin" />
                  ) : (
                    'Ready to roll ▶'
                  )}
                </button>
              </div>
            )}

            {/* Login error */}
            {loginMutation.isError && (
              <div className="mt-4 text-center">
                <p className="text-sm text-brand-pink font-semibold">
                  {getFriendlyError(loginMutation.error)} 😥
                </p>
              </div>
            )}

            {/* Bottom actions */}
            <div className="flex flex-col sm:flex-row items-center justify-between gap-4 mt-8 pt-6 border-t border-border-light">
              <Link
                to="/student-entry"
                className="inline-flex items-center gap-1.5 rounded-full border border-border-light bg-bg-card px-4 py-2 text-xs font-semibold text-brand-blue shadow-soft transition-colors hover:bg-brand-blue/5 hover:border-brand-blue/30"
              >
                <ArrowLeft size={14} />
                Back to Classes
              </Link>

              <button
                type="button"
                onClick={() => navigate('/student-entry/create-student')}
                className="inline-flex items-center gap-2 rounded-full border-2 border-dashed border-brand-pink/40 bg-brand-pink/5 px-5 py-2.5 text-xs sm:text-sm font-bold text-brand-pink transition-all hover:bg-brand-pink/10 hover:border-brand-pink/60 cursor-pointer"
                id="cant-find-name"
              >
                <Search size={14} />
                I can&apos;t find my name 🙋
              </button>

              <button
                type="button"
                disabled={!selectedStudent || loginMutation.isPending}
                onClick={handleLogin}
                className={`
                  inline-flex items-center gap-2 rounded-full px-6 py-3 text-sm font-bold
                  shadow-card transition-all duration-200 cursor-pointer
                  ${selectedStudent
                    ? 'bg-brand-blue text-white hover:brightness-110 hover:shadow-lg hover:-translate-y-0.5'
                    : 'bg-gray-200 text-text-muted cursor-not-allowed'
                  }
                `}
                dir="rtl"
                id="enter-hope-world"
              >
                {loginMutation.isPending ? (
                  <Loader2 size={16} className="animate-spin" />
                ) : (
                  <>
                    <span>ادخل عالم الأمل</span>
                    <span dir="ltr">Enter Hope World 🚀</span>
                  </>
                )}
              </button>
            </div>
          </>
        )}
      </div>
    </Layout>
  )
}
