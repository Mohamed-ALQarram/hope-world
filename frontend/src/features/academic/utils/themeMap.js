/**
 * Maps semantic theme identifiers (from backend subject data)
 * to Tailwind classes built from Hope World brand design tokens.
 *
 * Backend sends: theme: "yellow" | "blue" | ...
 * Frontend resolves to the corresponding brand-* Tailwind classes.
 *
 * To add a new subject theme, add a new key here — no SubjectCard changes needed.
 */

const THEME_MAP = {
  yellow: {
    accent: 'text-brand-yellow',
    accentBg: 'bg-brand-yellow',
    accentBgLight: 'bg-brand-yellow/15',
    ctaBg: 'bg-brand-yellow',
    ctaText: 'text-brand-navy',
    ctaHover: 'hover:brightness-110',
    progressBar: 'bg-brand-yellow',
    progressTrack: 'bg-brand-yellow/20',
    border: 'border-brand-yellow/30',
    borderHover: 'hover:border-brand-yellow/50',
    badgeText: 'text-amber-700',
    badgeBg: 'bg-brand-yellow/15',
    starBadge: 'bg-brand-yellow text-brand-navy',
    tagBg: 'bg-brand-yellow/10',
    tagText: 'text-amber-700',
    ring: 'ring-brand-yellow/30',
  },
  blue: {
    accent: 'text-brand-blue',
    accentBg: 'bg-brand-blue',
    accentBgLight: 'bg-brand-blue/15',
    ctaBg: 'bg-brand-blue',
    ctaText: 'text-white',
    ctaHover: 'hover:brightness-110',
    progressBar: 'bg-brand-blue',
    progressTrack: 'bg-brand-blue/20',
    border: 'border-brand-blue/30',
    borderHover: 'hover:border-brand-blue/50',
    badgeText: 'text-brand-blue',
    badgeBg: 'bg-brand-blue/15',
    starBadge: 'bg-brand-yellow text-brand-navy',
    tagBg: 'bg-brand-blue/10',
    tagText: 'text-brand-blue',
    ring: 'ring-brand-blue/30',
  },
}

/** Default fallback theme if the key is unknown */
const DEFAULT_THEME = 'blue'

/**
 * Resolve a semantic theme key to its Tailwind class map.
 * @param {string} themeKey - e.g. "yellow", "blue"
 * @returns {object} Map of role → Tailwind class string
 */
export function getTheme(themeKey) {
  return THEME_MAP[themeKey] ?? THEME_MAP[DEFAULT_THEME]
}

export default THEME_MAP
