import { AVATAR_OPTIONS } from '../utils/dummyVisuals'

/**
 * Grid of selectable avatar/buddy options for the Create Student screen.
 * Frontend-only — the selected avatar is NOT sent to the backend.
 *
 * @param {{ selectedKey: string|null, onSelect: (key: string) => void }} props
 */
export default function AvatarPicker({ selectedKey, onSelect }) {
  return (
    <div className="space-y-3">
      <h3 className="text-sm sm:text-base font-bold text-brand-navy m-0">
        2. Choose Your Buddy
        <span className="block text-[0.7rem] font-medium text-text-secondary mt-0.5" dir="rtl">
          اختر رفيقك المفضل
        </span>
      </h3>

      <p className="text-[0.75rem] text-text-secondary m-0">
        Click to switch characters!
      </p>

      <div className="grid grid-cols-3 sm:grid-cols-6 gap-3">
        {AVATAR_OPTIONS.map((avatar) => {
          const isActive = selectedKey === avatar.key
          return (
            <button
              key={avatar.key}
              type="button"
              onClick={() => onSelect(avatar.key)}
              className={`
                group flex flex-col items-center gap-1.5 rounded-xl border-2 bg-bg-card p-3
                transition-all duration-200 cursor-pointer
                hover:shadow-soft hover:-translate-y-0.5 hover:border-brand-blue/40
                focus-visible:outline-3 focus-visible:outline-brand-blue focus-visible:outline-offset-2
                ${isActive
                  ? 'border-brand-blue ring-3 ring-brand-blue/20 shadow-glow-blue bg-brand-blue/5'
                  : 'border-border-card'
                }
              `}
              aria-label={`Select buddy ${avatar.name}`}
              aria-pressed={isActive}
              id={`avatar-${avatar.key}`}
            >
              <span
                className={`
                  text-2xl sm:text-3xl transition-transform duration-200
                  ${isActive ? 'scale-110' : 'group-hover:scale-105'}
                `}
                aria-hidden="true"
              >
                {avatar.emoji}
              </span>
              <span className="text-[0.6rem] sm:text-[0.65rem] font-semibold text-brand-navy leading-tight text-center">
                {avatar.name}
              </span>
              <span className="text-[0.5rem] sm:text-[0.55rem] text-text-muted leading-tight text-center" dir="rtl">
                {avatar.nameAr}
              </span>
            </button>
          )
        })}
      </div>
    </div>
  )
}
