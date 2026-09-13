import { Link } from 'react-router-dom'
import { Home, Star, Volume2, User } from 'lucide-react'
import { useStudentEntryStore } from '../features/student-entry/store/useStudentEntryStore'
import { AVATAR_OPTIONS } from '../features/student-entry/utils/dummyVisuals'

export default function Header() {
  const avatarKey = useStudentEntryStore((s) => s.selectedAvatar)
  const avatar = AVATAR_OPTIONS.find((a) => a.key === avatarKey)

  return (
    <header className="sticky top-0 z-50 bg-bg-header border-b border-border-light">
      <div className="max-w-6xl mx-auto px-4 sm:px-6 h-16 flex items-center justify-between">
        {/* Left — Brand */}
        <div className="flex items-center gap-3">
          <Link
            to="/"
            className="flex items-center justify-center w-10 h-10 rounded-full bg-brand-blue/10 text-brand-blue hover:bg-brand-blue/20 transition-colors"
            aria-label="Home"
          >
            <Home size={20} />
          </Link>
          <span className="text-lg sm:text-xl font-extrabold tracking-tight text-brand-navy">
            HOPE WORLD{' '}
            <span className="text-brand-yellow" aria-hidden="true">✦</span>
          </span>
        </div>

        {/* Right — Actions */}
        <div className="flex items-center gap-2 sm:gap-3">
          {/* Stars badge */}
          <div className="flex items-center gap-1.5 px-3 py-1.5 rounded-full border border-border-light bg-white shadow-soft text-sm font-semibold text-brand-navy">
            <Star size={16} className="text-brand-yellow fill-brand-yellow" />
            <span>140</span>
          </div>

          {/* Sound toggle */}
          <button
            type="button"
            className="flex items-center justify-center w-10 h-10 rounded-full border border-border-light bg-white shadow-soft text-text-secondary hover:text-brand-navy hover:border-brand-blue/40 transition-colors"
            aria-label="Toggle sound"
          >
            <Volume2 size={18} />
          </button>

          {/* Avatar */}
          <button
            type="button"
            className="flex items-center justify-center w-10 h-10 rounded-full border-2 border-brand-yellow bg-brand-yellow/20 text-brand-navy shadow-soft overflow-hidden hover:border-brand-yellow/80 transition-colors"
            aria-label="Profile"
          >
            {avatar ? (
              <span className="text-lg leading-none" aria-hidden="true">{avatar.emoji}</span>
            ) : (
              <User size={18} />
            )}
          </button>
        </div>
      </div>
    </header>
  )
}
