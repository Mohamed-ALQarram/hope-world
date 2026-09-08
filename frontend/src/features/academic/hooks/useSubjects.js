import { useState, useEffect } from 'react'
import arabicImg from '../../../assets/subjects/arabic.png'
import englishImg from '../../../assets/subjects/english.png'

/**
 * Mock subject data matching the expected API contract.
 *
 * When the backend endpoint is ready, replace this with:
 *   import { useQuery } from '@tanstack/react-query'
 *   import { fetchSubjects } from '../api/subjects'
 *   ...
 *   const { data, isLoading, isError } = useQuery({ queryKey: ['subjects'], queryFn: fetchSubjects })
 *
 * The returned shape ({ subjects, isLoading, isError }) stays the same.
 */
const MOCK_SUBJECTS = [
  {
    id: 'arabic',
    name: 'اللغة العربية',
    nameSecondary: 'Arabic Adventure',
    description:
      'Hop onto the magic carpet! Discover Arabic alphabet sounds, playful animals, and write your first enchanted words with Harakat!',
    image: arabicImg,
    theme: 'yellow',
    progress: 0,
    totalLevels: 12,
    currentLevel: 'Level 1: Ready to Start!',
    starsToCollect: 36,
    tags: ['Phonics & Shapes', '8 Mini-Games'],
    cta: 'ابدأ رحلة العربية',
    ctaIcon: '→',
    locale: 'ar',
    subtitle: 'رحلة الحروف والكلمات',
    status: 'available',
  },
  {
    id: 'english',
    name: 'English',
    nameSecondary: 'Letters & Phonics',
    description:
      'Blast off into story land! Sing the ABC song, tap funny rhyming bubbles, and unlock magical talking animal storybooks!',
    image: englishImg,
    theme: 'blue',
    progress: 0,
    totalLevels: 12,
    currentLevel: 'Unlocked • Ready to Play!',
    starsToCollect: 36,
    tags: ['Audio Phonics', 'Word Puzzles'],
    cta: 'Start English Journey',
    ctaIcon: '🚀',
    locale: 'en',
    subtitle: 'Phonics & Early Reading',
    status: 'available',
  },
]

/**
 * Hook to fetch academic subjects.
 *
 * Currently returns mock data.
 * Swap internals to TanStack Query when the API endpoint is ready —
 * consumers (SubjectSelectionPage, SubjectCard) require no changes.
 *
 * @returns {{ subjects: Array, isLoading: boolean, isError: boolean }}
 */
export function useSubjects() {
  const [subjects, setSubjects] = useState(null)
  const [isLoading, setIsLoading] = useState(true)
  const [isError] = useState(false)

  useEffect(() => {
    // Simulate network delay
    const timer = setTimeout(() => {
      setSubjects(MOCK_SUBJECTS)
      setIsLoading(false)
    }, 400)

    return () => clearTimeout(timer)
  }, [])

  return { subjects: subjects ?? [], isLoading, isError }
}
