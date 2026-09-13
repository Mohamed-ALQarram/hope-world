import { Users } from 'lucide-react'
import { getClassVisual } from '../utils/dummyVisuals'

/**
 * Large, child-friendly selectable card for a single class.
 *
 * @param {{ cls: { classId: number, className: string }, index: number, isSelected: boolean, onSelect: () => void }} props
 */
export default function ClassCard({ cls, index, isSelected, onSelect }) {
  const visual = getClassVisual(index)

  return (
    <button
      type="button"
      onClick={onSelect}
      className={`
        group relative flex flex-col items-center gap-3 rounded-2xl border-2 bg-bg-card p-5 sm:p-6
        shadow-card transition-all duration-200 cursor-pointer
        hover:shadow-lg hover:-translate-y-1 hover:border-brand-blue/50
        focus-visible:outline-3 focus-visible:outline-brand-blue focus-visible:outline-offset-2
        ${isSelected
          ? 'border-brand-blue ring-4 ring-brand-blue/20 shadow-glow-blue'
          : 'border-border-card'
        }
      `}
      aria-label={`Select class ${cls.className}`}
      aria-pressed={isSelected}
      id={`class-card-${cls.classId}`}
    >
      {/* Decorative icon */}
      <div
        className={`
          flex items-center justify-center w-16 h-16 sm:w-20 sm:h-20 rounded-full
          bg-gradient-to-br ${visual.gradient}
          text-3xl sm:text-4xl shadow-soft
          transition-transform duration-200 group-hover:scale-110
        `}
        aria-hidden="true"
      >
        {visual.emoji}
      </div>

      {/* Class name */}
      <h3 className="text-base sm:text-lg font-bold text-brand-navy text-center m-0">
        {cls.className}
      </h3>

      {/* Dummy visual label */}
      <span className="text-[0.7rem] sm:text-xs text-text-secondary font-medium text-center">
        {visual.label}
      </span>

      {/* Dummy student count badge */}
      <div className="flex items-center gap-1.5 rounded-full bg-brand-blue/10 px-3 py-1 text-[0.65rem] sm:text-xs font-semibold text-brand-blue">
        <Users size={12} />
        <span>{4 + (cls.classId % 5)} Little Explorers</span>
      </div>

      {/* Selected check indicator */}
      {isSelected && (
        <div className="absolute top-2.5 right-2.5 flex items-center justify-center w-6 h-6 rounded-full bg-brand-blue text-white shadow-soft">
          <svg width="14" height="14" viewBox="0 0 24 24" fill="none" stroke="currentColor" strokeWidth="3" strokeLinecap="round" strokeLinejoin="round">
            <polyline points="20 6 9 17 4 12" />
          </svg>
        </div>
      )}
    </button>
  )
}
