import { useEffect } from 'react'
import { useNavigate, Link } from 'react-router-dom'
import { useForm } from 'react-hook-form'
import * as yup from 'yup'
import { ArrowLeft, Loader2, Sparkles, Shield } from 'lucide-react'
import Layout from '../components/Layout'
import StepIndicator from '../features/student-entry/components/StepIndicator'
import AvatarPicker from '../features/student-entry/components/AvatarPicker'
import { useStudentRegister } from '../features/student-entry/hooks/useStudentRegister'
import { useStudentEntryStore } from '../features/student-entry/store/useStudentEntryStore'
import { AVATAR_OPTIONS } from '../features/student-entry/utils/dummyVisuals'

const nameSchema = yup.object({
  studentName: yup
    .string()
    .trim()
    .required('Please enter your name')
    .min(2, 'Name must be at least 2 characters'),
})

/** Extract a friendly message from an Axios error (backend sends { error: "..." }). */
function getFriendlyError(err) {
  return err?.response?.data?.error || 'Something went wrong. Please try again!'
}

export default function CreateStudentPage() {
  const navigate = useNavigate()
  const selectedClass = useStudentEntryStore((s) => s.selectedClass)
  const setSelectedAvatar = useStudentEntryStore((s) => s.setSelectedAvatar)
  const selectedAvatar = useStudentEntryStore((s) => s.selectedAvatar)

  // Guard: redirect if no class selected
  useEffect(() => {
    if (!selectedClass) navigate('/', { replace: true })
  }, [selectedClass, navigate])

  const registerMutation = useStudentRegister()

  const {
    register,
    handleSubmit,
    watch,
    setError,
    formState: { errors },
  } = useForm({
    defaultValues: { studentName: '' },
    mode: 'onTouched',
  })

  // Default avatar on mount
  useEffect(() => {
    if (!selectedAvatar) setSelectedAvatar(AVATAR_OPTIONS[0].key)
  }, [selectedAvatar, setSelectedAvatar])

  const avatarKey = selectedAvatar || AVATAR_OPTIONS[0].key
  const currentAvatar = AVATAR_OPTIONS.find((a) => a.key === avatarKey)
  const studentName = watch('studentName')

  if (!selectedClass) return null

  async function onSubmit(values) {
    try {
      const validated = await nameSchema.validate(values, { abortEarly: false })
      registerMutation.mutate({
        className: selectedClass.className,
        studentName: validated.studentName,
      })
    } catch (err) {
      if (err instanceof yup.ValidationError) {
        err.inner.forEach((e) => {
          setError(e.path, { message: e.message })
        })
      }
    }
  }

  return (
    <Layout>
      <div className="mx-auto max-w-4xl px-4 sm:px-6 pb-10">
        <StepIndicator currentStep={3} />

        {/* Page Header */}
        <div className="pt-2 pb-6 text-center">
          <div className="flex justify-center mb-3">
            <span className="inline-flex items-center gap-1.5 rounded-full bg-brand-pink/10 px-4 py-1.5 text-xs font-bold tracking-wide text-brand-pink">
              <Sparkles size={14} />
              Joining Class {selectedClass.className}
            </span>
          </div>

          <h1 className="text-2xl sm:text-3xl font-extrabold text-brand-navy tracking-tight m-0">
            What&apos;s your name, adventurer?{' '}
            <span className="inline-block animate-pulse" aria-hidden="true">✨🎒</span>
          </h1>
          <p className="mt-1 text-base font-bold text-brand-blue m-0" dir="rtl">
            ما اسمك يا مستكشف؟ 🌟
          </p>
          <p className="mt-2 text-sm text-text-secondary max-w-lg mx-auto leading-relaxed">
            Type your name and pick your favorite buddy avatar to jump right into the island! Zero passwords, zero fuss.
          </p>
        </div>

        {/* Form */}
        <form onSubmit={handleSubmit(onSubmit)}>
          <div className="grid grid-cols-1 lg:grid-cols-5 gap-6">
            {/* Left — Name + Avatar */}
            <div className="lg:col-span-3 space-y-6">
              {/* Name Input */}
              <div className="rounded-2xl border border-border-card bg-bg-card p-5 sm:p-6 shadow-card space-y-4">
                <div className="flex items-center justify-between">
                  <h3 className="text-sm sm:text-base font-bold text-brand-navy m-0">
                    1. Your Adventurer Name
                    <span className="block text-[0.7rem] font-medium text-text-secondary mt-0.5" dir="rtl">
                      اسم المغامر الخاص بك
                    </span>
                  </h3>
                  <span className="inline-flex items-center gap-1 rounded-full bg-green-100 px-2.5 py-1 text-[0.65rem] font-semibold text-green-700">
                    <Shield size={11} />
                    Safe for You!
                  </span>
                </div>

                <p className="text-[0.75rem] text-text-secondary m-0">
                  No full names or secrets needed — just what your friends call you! 😊
                </p>

                <div>
                  <div className="relative">
                    <input
                      {...register('studentName')}
                      type="text"
                      placeholder="e.g. Ahmed, ليلى, Rami..."
                      maxLength={50}
                      className={`
                        w-full rounded-xl border-2 bg-white px-4 py-3.5 text-base font-semibold text-brand-navy
                        placeholder:text-text-muted/50 placeholder:font-normal
                        transition-colors duration-200
                        focus:outline-none focus:ring-3 focus:ring-brand-blue/20 focus:border-brand-blue
                        ${errors.studentName
                          ? 'border-brand-pink ring-2 ring-brand-pink/20'
                          : 'border-border-card hover:border-brand-blue/40'
                        }
                      `}
                      id="student-name-input"
                      autoComplete="off"
                      aria-label="Your adventurer name"
                      aria-describedby={errors.studentName ? 'name-error' : undefined}
                    />
                    {studentName && (
                      <span className="absolute right-3 top-1/2 -translate-y-1/2 text-lg" aria-hidden="true">✏️</span>
                    )}
                  </div>
                  {errors.studentName && (
                    <p id="name-error" className="mt-1.5 text-xs text-brand-pink font-medium" role="alert">
                      {errors.studentName.message}
                    </p>
                  )}
                  <p className="mt-1.5 text-[0.65rem] text-text-muted">
                    👆 This full name appears on screen to identify you
                  </p>
                </div>
              </div>

              {/* Avatar Picker */}
              <div className="rounded-2xl border border-border-card bg-bg-card p-5 sm:p-6 shadow-card">
                <AvatarPicker
                  selectedKey={avatarKey}
                  onSelect={setSelectedAvatar}
                />
              </div>
            </div>

            {/* Right — Quest Passport Preview */}
            <div className="lg:col-span-2">
              <div className="rounded-2xl border-2 border-brand-yellow/30 bg-gradient-to-br from-brand-yellow/10 to-brand-blue/5 p-5 sm:p-6 shadow-card sticky top-24 space-y-4">
                <div className="flex items-center justify-between">
                  <span className="text-xs font-bold text-brand-navy tracking-wide uppercase">Quest Passport</span>
                  <span className="text-xs font-bold text-brand-pink">New to Town!</span>
                </div>

                <div className="flex flex-col items-center gap-3">
                  <div className="flex items-center justify-center w-24 h-24 rounded-full bg-gradient-to-br from-brand-blue/20 to-brand-yellow/20 border-3 border-brand-yellow text-5xl shadow-glow-yellow">
                    {currentAvatar?.emoji || '🎭'}
                  </div>
                  <div className="text-center">
                    <p className="text-sm font-bold text-brand-blue m-0">Hello, my name is</p>
                    <p className="text-xl font-extrabold text-brand-navy m-0 mt-1">
                      {studentName?.trim() || '???'}
                    </p>
                  </div>
                </div>

                <div className="rounded-xl bg-white/60 border border-border-light p-3 space-y-2">
                  <p className="text-[0.65rem] font-bold text-text-muted uppercase tracking-wide m-0">Adventure Unlocked</p>
                  <div className="flex items-center justify-between text-xs">
                    <span className="text-text-secondary">⭐ +50 Stars & Explorer Badge</span>
                  </div>
                  <p className="text-[0.6rem] text-brand-blue font-semibold m-0">Brave, curious, and loves stories! 🌈</p>
                </div>

                <p className="text-[0.65rem] text-text-muted text-center m-0">🏫 Class: {selectedClass.className}</p>
              </div>
            </div>
          </div>

          {/* Registration error */}
          {registerMutation.isError && (
            <div className="mt-4 text-center">
              <p className="text-sm text-brand-pink font-semibold">
                {getFriendlyError(registerMutation.error)} 😥
              </p>
            </div>
          )}

          {/* Bottom actions */}
          <div className="flex flex-col sm:flex-row items-center justify-between gap-4 mt-8 pt-6 border-t border-border-light">
            <Link
              to="/choose-student"
              className="inline-flex items-center gap-1.5 rounded-full border border-border-light bg-bg-card px-4 py-2 text-xs font-semibold text-brand-blue shadow-soft transition-colors hover:bg-brand-blue/5 hover:border-brand-blue/30"
            >
              <ArrowLeft size={14} />
              Back to Students
            </Link>

            <button
              type="submit"
              disabled={registerMutation.isPending}
              className={`
                inline-flex items-center gap-2 rounded-full px-8 py-3.5 text-sm sm:text-base font-bold
                shadow-card transition-all duration-200 cursor-pointer
                ${!registerMutation.isPending
                  ? 'bg-gradient-to-r from-brand-blue to-brand-pink text-white hover:brightness-110 hover:shadow-lg hover:-translate-y-0.5'
                  : 'bg-gray-200 text-text-muted cursor-not-allowed'
                }
              `}
              id="start-adventure"
            >
              {registerMutation.isPending ? (
                <Loader2 size={18} className="animate-spin" />
              ) : (
                <>
                  <span>Start Adventure! 🚀</span>
                  <span className="text-xs opacity-80" dir="rtl">ابدأ المغامرة</span>
                </>
              )}
            </button>
          </div>

          <div className="mt-6 text-center">
            <p className="text-[0.7rem] text-text-muted">
              📝 Need a hand? Teachers can adjust your name later inside the Teacher Dashboard settings.
            </p>
            <p className="text-[0.65rem] text-text-muted mt-1" dir="rtl">
              هل تحتاج مساعدة؟ يمكن للمعلم تعديل الاسم لاحقاً
            </p>
          </div>
        </form>
      </div>
    </Layout>
  )
}
