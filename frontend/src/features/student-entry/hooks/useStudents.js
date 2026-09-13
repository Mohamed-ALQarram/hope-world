import { useQuery } from '@tanstack/react-query'
import { getStudentsByClass } from '../api/studentEntryApi'

/**
 * Fetches students belonging to a specific class.
 * Only runs when classId is truthy (enabled guard).
 */
export function useStudents(classId) {
  return useQuery({
    queryKey: ['students', classId],
    queryFn: () => getStudentsByClass(classId),
    enabled: !!classId,
  })
}
