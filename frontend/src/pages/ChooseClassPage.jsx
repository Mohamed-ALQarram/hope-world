import { useState } from 'react'
import { useNavigate } from 'react-router-dom'
import { Loader2, RefreshCw, Sparkles } from 'lucide-react'
import Layout from '../components/Layout'
import StepIndicator from '../features/student-entry/components/StepIndicator'
import ClassCard from '../features/student-entry/components/ClassCard'
import { useClasses } from '../features/student-entry/hooks/useClasses'
import { useStudentEntryStore } from '../features/student-entry/store/useStudentEntryStore'

export default function ChooseClassPage() {
  const navigate = useNavigate()
  const { data: classes, isLoading, isError, refetch } = useClasses()
  const setSelectedClass = useStudentEntryStore((s) => s.setSelectedClass)

  const [selectedId, setSelectedId] = useState(null)

  function handleSelect(cls) {
    setSelectedId(cls.classId)
  }

  function handleContinue() {
    const cls = classes?.find((c) => c.classId === selectedId)
    if (!cls) return
    setSelectedClass(cls)
    navigate('/student-entry/choose-student')
  }

  return (
    <Layout>
      <div className="mx-auto max-w-5xl px-4 sm:px-6 pb-10">
        {/* Step Indicator */}
        <StepIndicator currentStep={1} />

        {/* Page Header */}
        <div className="pt-2 pb-6 sm:pb-8 text-center">
          <div className="flex justify-center mb-3">
            <span className="inline-flex items-center gap-1.5 rounded-full bg-brand-yellow/15 px-4 py-1.5 text-xs font-bold tracking-wide text-amber-700">
              <Sparkles size={14} />
              Adventure Awaits!
            </span>
          </div>

          <h1 className="text-2xl sm:text-4xl font-extrabold text-brand-navy tracking-tight m-0">
            Which class are you in?{' '}
            <span className="inline-block animate-pulse" aria-hidden="true">✨</span>
          </h1>

          <p className="mt-2 text-base sm:text-lg font-bold text-brand-blue m-0" dir="rtl">
            أين فصلك الجميل؟ 🌟
          </p>

          <p className="mt-2 text-sm sm:text-base text-text-secondary max-w-lg mx-auto leading-relaxed">
            Tap your friendly classroom door to hop right into Hope World! 🚪
          </p>
        </div>

        {/* Loading */}
        {isLoading && (
          <div className="flex flex-col items-center justify-center py-20 gap-3">
            <Loader2 size={32} className="text-brand-blue animate-spin" />
            <p className="text-sm text-text-muted font-medium">Loading classes…</p>
          </div>
        )}

        {/* Error */}
        {isError && (
          <div className="flex flex-col items-center justify-center py-16 gap-4">
            <div className="text-4xl" aria-hidden="true">😥</div>
            <p className="text-brand-pink font-semibold text-lg m-0">Oops! Something went wrong</p>
            <p className="text-text-secondary text-sm m-0">We couldn&apos;t load the classes. Let&apos;s try again!</p>
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

        {/* Empty */}
        {!isLoading && !isError && classes?.length === 0 && (
          <div className="text-center py-16">
            <div className="text-4xl mb-3" aria-hidden="true">🏫</div>
            <p className="text-brand-navy font-semibold text-lg mb-2 m-0">No classes available yet!</p>
            <p className="text-text-secondary text-sm m-0">Check back soon — your classroom is being prepared.</p>
          </div>
        )}

        {/* Class Grid */}
        {!isLoading && !isError && classes && classes.length > 0 && (
          <>
            <div className="grid grid-cols-2 sm:grid-cols-3 lg:grid-cols-4 gap-4 sm:gap-5">
              {classes.map((cls, i) => (
                <ClassCard
                  key={cls.classId}
                  cls={cls}
                  index={i}
                  isSelected={selectedId === cls.classId}
                  onSelect={() => handleSelect(cls)}
                />
              ))}
            </div>

            <div className="flex justify-center mt-8">
              <button
                type="button"
                disabled={selectedId === null}
                onClick={handleContinue}
                className={`
                  inline-flex items-center gap-2 rounded-full px-8 py-3.5 text-sm sm:text-base font-bold
                  shadow-card transition-all duration-200 cursor-pointer
                  ${selectedId !== null
                    ? 'bg-brand-blue text-white hover:brightness-110 hover:shadow-lg hover:-translate-y-0.5'
                    : 'bg-gray-200 text-text-muted cursor-not-allowed'
                  }
                `}
                id="continue-to-students"
              >
                Continue to Choose Name →
              </button>
            </div>
          </>
        )}
      </div>
    </Layout>
  )
}
