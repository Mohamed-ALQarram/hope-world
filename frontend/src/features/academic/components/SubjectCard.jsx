import { Link } from 'react-router-dom'
import { Volume2, Star, Lock, Bookmark, Layers } from 'lucide-react'
import { getTheme } from '../utils/themeMap'

/**
 * Reusable subject card component.
 * All visual accents are driven by the subject's semantic theme — never hard-coded per subject.
 *
 * @param {{ subject: object }} props
 */
export default function SubjectCard({ subject }) {
  const t = getTheme(subject.theme)
  const isRTL = subject.locale === 'ar'

  return (
    <Link
      to={`/academic/${subject.id}`}
      className={`group block rounded-2xl border bg-bg-card shadow-card transition-all duration-200 hover:shadow-lg hover:-translate-y-0.5 focus-visible:outline-3 focus-visible:outline-brand-blue focus-visible:outline-offset-2 ${t.border}`}
      aria-label={`${subject.name} — ${subject.nameSecondary}`}
    >
      {/* ── Header Row ── */}
      <div className="flex items-center justify-between px-4 pt-3.5 pb-2">
        <div
          className={`flex items-center gap-1.5 text-xs font-semibold ${t.badgeText}`}
          dir={isRTL ? 'rtl' : 'ltr'}
        >
          <Bookmark size={13} className="shrink-0" />
          <span>{subject.subtitle}</span>
        </div>
        <div className={`flex items-center gap-1.5 rounded-full px-2.5 py-1 text-xs font-bold ${t.starBadge}`}>
          <Star size={12} className="fill-current" />
          <span>{subject.starsToCollect} Stars to Collect</span>
        </div>
      </div>

      {/* ── Image Area ── */}
      <div className="relative mx-3 overflow-hidden rounded-xl">
        <img
          src={subject.image}
          alt={`${subject.name} learning illustration`}
          className="block w-full h-44 sm:h-52 object-cover transition-transform duration-300 group-hover:scale-[1.03]"
          loading="lazy"
        />

        {/* Overlay badges */}
        <div className="absolute top-2.5 left-2.5 flex flex-col gap-1.5">
          <span className="inline-flex items-center gap-1 rounded-full bg-white/90 px-2.5 py-1 text-[0.7rem] font-semibold text-brand-navy backdrop-blur-sm">
            <span className={`inline-block size-2 rounded-full ${t.accentBg}`} />
            {subject.totalLevels} Fun Levels
          </span>
        </div>
        <div className="absolute top-2.5 right-2.5">
          <span className="inline-flex items-center gap-1 rounded-full bg-white/90 px-2.5 py-1 text-[0.7rem] font-semibold text-brand-navy backdrop-blur-sm">
            Subject Selection
          </span>
        </div>

        {/* Audio button */}
        <button
          type="button"
          className="absolute bottom-2.5 right-2.5 flex size-9 items-center justify-center rounded-full bg-white/90 text-brand-navy shadow-soft backdrop-blur-sm transition-colors hover:bg-white"
          aria-label={`Listen to ${subject.name} introduction`}
          onClick={(e) => e.preventDefault()}
        >
          <Volume2 size={16} />
        </button>
      </div>

      {/* ── Title Row ── */}
      <div className="flex items-baseline justify-between gap-3 px-4 pt-3.5" dir={isRTL ? 'rtl' : 'ltr'}>
        <h3 className="text-xl font-bold text-brand-navy leading-tight m-0">
          {subject.name}
        </h3>
        <span className={`text-xs font-semibold whitespace-nowrap ${t.accent}`}>
          {subject.nameSecondary}
        </span>
      </div>

      {/* ── Description ── */}
      <p
        className="px-4 pt-1.5 text-[0.8rem] leading-relaxed text-text-secondary m-0"
        dir={isRTL ? 'rtl' : 'ltr'}
      >
        {subject.description}
      </p>

      {/* ── Progress Section ── */}
      <div className={`mx-4 mt-3.5 rounded-lg border px-3.5 py-2.5 ${t.badgeBg} ${t.border}`}>
        <div className="flex items-center justify-between text-xs">
          <span className="flex items-center gap-1.5 font-semibold text-brand-navy">
            {subject.progress > 0 ? (
              <Layers size={13} className={t.accent} />
            ) : (
              <Lock size={13} className={t.accent} />
            )}
            {subject.currentLevel}
          </span>
          <span className="font-bold text-text-muted" dir="ltr">
            {subject.progress}% Complete
          </span>
        </div>

        {/* Progress bar */}
        <div className={`mt-2 h-1.5 w-full overflow-hidden rounded-full ${t.progressTrack}`}>
          <div
            className={`h-full rounded-full transition-all duration-500 ${t.progressBar}`}
            style={{ width: `${Math.max(subject.progress, 2)}%` }}
          />
        </div>
      </div>

      {/* ── Tags Row ── */}
      <div className="flex items-center justify-between px-4 pt-2.5 pb-3">
        {subject.tags.map((tag) => (
          <span
            key={tag}
            className={`inline-flex items-center gap-1 text-[0.7rem] font-medium ${t.tagText}`}
          >
            <span className="opacity-60">◇</span>
            {tag}
          </span>
        ))}
      </div>

      {/* ── CTA Button ── */}
      <div className="px-3 pb-3.5">
        <span
          className={`flex w-full items-center justify-center gap-2 rounded-xl py-3 text-sm font-bold transition-all duration-200 group-hover:brightness-110 ${t.ctaBg} ${t.ctaText}`}
          dir={isRTL ? 'rtl' : 'ltr'}
        >
          {subject.cta}
          <span dir="ltr" aria-hidden="true">{subject.ctaIcon}</span>
        </span>
      </div>
    </Link>
  )
}
