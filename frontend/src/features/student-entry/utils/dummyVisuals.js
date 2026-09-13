/**
 * Frontend-only visual fallbacks for classes and students.
 *
 * The backend does NOT provide icons, images, or avatars yet.
 * All dummy visuals live here so they are easy to replace later.
 *
 * DO NOT import these values into API models — they are purely presentational.
 */

// ── Class card visuals ──────────────────────────────────────────────

const CLASS_VISUALS = [
  { emoji: '⭐', label: 'Star Explorers', gradient: 'from-amber-400 to-yellow-300' },
  { emoji: '🌈', label: 'Rainbow Dreamers', gradient: 'from-purple-400 to-pink-300' },
  { emoji: '🚀', label: 'Rocket Champions', gradient: 'from-sky-400 to-blue-300' },
  { emoji: '🌱', label: 'Little Sprouts', gradient: 'from-emerald-400 to-green-300' },
  { emoji: '🎨', label: 'Creative Crew', gradient: 'from-rose-400 to-orange-300' },
  { emoji: '🐬', label: 'Ocean Explorers', gradient: 'from-cyan-400 to-teal-300' },
  { emoji: '🦁', label: 'Brave Lions', gradient: 'from-orange-400 to-amber-300' },
  { emoji: '🌙', label: 'Moon Walkers', gradient: 'from-indigo-400 to-violet-300' },
]

/**
 * Get a visual config for a class by its index or classId.
 * Cycles through available visuals if more classes than visuals.
 */
export function getClassVisual(index) {
  return CLASS_VISUALS[index % CLASS_VISUALS.length]
}

// ── Student avatars ─────────────────────────────────────────────────

export const AVATAR_OPTIONS = [
  { key: 'bunny-fluff', emoji: '🐰', name: 'Bunny Fluff', nameAr: 'أرنوب' },
  { key: 'sparkly-parrot', emoji: '🦜', name: 'Sparkly Parrot', nameAr: 'ببغاء لامع' },
  { key: 'fox-rami', emoji: '🦊', name: 'Fox Rami', nameAr: 'ثعلب رامي' },
  { key: 'little-leo', emoji: '🦁', name: 'Little Leo', nameAr: 'ليو الصغير' },
  { key: 'star-laila', emoji: '⭐', name: 'Star Laila', nameAr: 'ليلى النجمة' },
  { key: 'sprite-dino', emoji: '🦕', name: 'Sprite Dino', nameAr: 'ديناصور' },
]

/**
 * Deterministic avatar for a student based on their studentId.
 * Used in the student list before the user picks their own buddy.
 */
export function getStudentAvatar(studentId) {
  return AVATAR_OPTIONS[studentId % AVATAR_OPTIONS.length]
}

// ── Dummy star/level data for student cards ──────────────────────────

const STAR_COUNTS = [90, 140, 85, 110, 65, 120, 95, 75]
const LEVEL_LABELS = ['Level 1', 'Level 2', 'Level 3', 'Level 1', 'Level 2', 'Level 1', 'Level 3', 'Level 2']

export function getStudentBadge(studentId) {
  return {
    stars: STAR_COUNTS[studentId % STAR_COUNTS.length],
    level: LEVEL_LABELS[studentId % LEVEL_LABELS.length],
  }
}
