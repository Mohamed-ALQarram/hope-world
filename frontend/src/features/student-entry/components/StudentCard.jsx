import { Star } from 'lucide-react'
import { getStudentAvatar, getStudentBadge } from '../utils/dummyVisuals'

/**
 * Student selection card with dummy avatar, name, and star/level badges.
 *
 * @param {{ student: { studentId: number, studentName: string }, isSelected: boolean, onSelect: () => void }} props
 */
export default function StudentCard({ student, isSelected, onSelect }) {
  const avatar = getStudentAvatar(student.studentId)
  const badge = getStudentBadge(student.studentId)

  return (
    <button
      type="button"
      onClick={onSelect}
      className={`
        group flex flex-col items-center gap-2.5 rounded-2xl border-2 bg-bg-card p-4 sm:p-5
        shadow-card transition-all duration-200 cursor-pointer
        hover:shadow-lg hover:-translate-y-1 hover:border-brand-blue/50
        focus-visible:outline-3 focus-visible:outline-brand-blue focus-visible:outline-offset-2
        ${isSelected
          ? 'border-brand-blue ring-4 ring-brand-blue/20 shadow-glow-blue'
          : 'border-border-card'
        }
      `}
      aria-label={`Select student ${student.studentName}`}
      aria-pressed={isSelected}
      id={`student-card-${student.studentId}`}
    >
      {/* Avatar circle */}
      <div
        className={`
          relative flex items-center justify-center w-16 h-16 sm:w-20 sm:h-20 rounded-full
          bg-gradient-to-br from-brand-blue/20 to-brand-yellow/20
          text-3xl sm:text-4xl
          border-3 transition-all duration-200
          ${isSelected
            ? 'border-brand-blue shadow-glow-blue'
            : 'border-border-card group-hover:border-brand-blue/40'
          }
        `}
        aria-hidden="true"
      >
        {avatar.emoji}

        {/* Selected badge */}
        {isSelected && (
          <div className="absolute -bottom-1 -right-1 flex items-center justify-center w-6 h-6 rounded-full bg-brand-blue text-white text-xs shadow-soft">
            ✓
          </div>
        )}
      </div>

      {/* Student name */}
      <div className="text-center">
        <h3 className="text-sm sm:text-base font-bold text-brand-navy m-0 leading-tight">
          {student.studentName}
        </h3>
        <span className="text-[0.65rem] sm:text-xs text-text-secondary font-medium">
          {avatar.name}
        </span>
      </div>

      {/* Stars & Level badges */}
      <div className="flex items-center gap-2">
        <span className="inline-flex items-center gap-1 rounded-full bg-brand-yellow/15 px-2 py-0.5 text-[0.6rem] sm:text-[0.7rem] font-bold text-amber-700">
          <Star size={10} className="fill-brand-yellow text-brand-yellow" />
          {badge.stars} Stars
        </span>
        <span className="inline-flex items-center rounded-full bg-brand-blue/10 px-2 py-0.5 text-[0.6rem] sm:text-[0.7rem] font-bold text-brand-blue">
          {badge.level}
        </span>
      </div>
    </button>
  )
}
