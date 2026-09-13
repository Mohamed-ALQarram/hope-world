import { useQuery } from '@tanstack/react-query'
import { getClasses } from '../api/studentEntryApi'

/**
 * Fetches all available classes.
 * Server state managed by TanStack Query — not duplicated in Zustand.
 */
export function useClasses() {
  return useQuery({
    queryKey: ['classes'],
    queryFn: getClasses,
  })
}
