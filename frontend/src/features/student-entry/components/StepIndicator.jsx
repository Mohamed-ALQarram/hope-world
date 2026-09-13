import { Check } from 'lucide-react'

const STEPS = [
  { num: 1, label: 'Choose Class', labelAr: 'اختيار الفصل', emoji: '🏫' },
  { num: 2, label: 'Find Character', labelAr: 'اختيار الشخصية', emoji: '👤' },
  { num: 3, label: 'Start Adventure', labelAr: 'بداية المغامرة', emoji: '🚀' },
]

/**
 * Horizontal 3-step progress indicator shown across all student entry screens.
 * @param {{ currentStep: number }} props — 1-indexed step number
 */
export default function StepIndicator({ currentStep }) {
  return (
    <nav
      className="flex items-center justify-center gap-0 py-4 px-2"
      aria-label="Onboarding progress"
    >
      {STEPS.map((step, i) => {
        const isCompleted = currentStep > step.num
        const isActive = currentStep === step.num

        return (
          <div key={step.num} className="flex items-center">
            {/* Step node */}
            <div className="flex flex-col items-center gap-1.5 min-w-[80px] sm:min-w-[100px]">
              {/* Circle */}
              <div
                className={`
                  flex items-center justify-center w-9 h-9 sm:w-10 sm:h-10 rounded-full text-sm font-bold
                  transition-all duration-300
                  ${isCompleted
                    ? 'bg-brand-blue text-white shadow-glow-blue'
                    : isActive
                      ? 'bg-brand-blue text-white shadow-glow-blue ring-4 ring-brand-blue/20'
                      : 'bg-gray-100 text-text-muted border border-border-light'
                  }
                `}
                aria-current={isActive ? 'step' : undefined}
              >
                {isCompleted ? <Check size={18} strokeWidth={3} /> : step.emoji}
              </div>

              {/* Labels */}
              <div className="text-center">
                <span
                  className={`block text-[0.65rem] sm:text-xs font-semibold leading-tight
                    ${isActive ? 'text-brand-blue' : isCompleted ? 'text-brand-navy' : 'text-text-muted'}
                  `}
                >
                  Step {step.num} of 3
                </span>
                <span
                  className={`block text-[0.6rem] sm:text-[0.7rem] font-medium leading-tight mt-0.5
                    ${isActive ? 'text-brand-navy' : isCompleted ? 'text-text-secondary' : 'text-text-muted'}
                  `}
                >
                  {step.label}
                </span>
                <span
                  className={`block text-[0.55rem] sm:text-[0.6rem] leading-tight mt-0.5
                    ${isActive || isCompleted ? 'text-text-secondary' : 'text-text-muted/60'}
                  `}
                  dir="rtl"
                >
                  {step.labelAr}
                </span>
              </div>
            </div>

            {/* Connector line */}
            {i < STEPS.length - 1 && (
              <div
                className={`
                  w-8 sm:w-14 h-0.5 rounded-full -mt-8
                  transition-colors duration-300
                  ${currentStep > step.num ? 'bg-brand-blue' : 'bg-border-light'}
                `}
                aria-hidden="true"
              />
            )}
          </div>
        )
      })}
    </nav>
  )
}
