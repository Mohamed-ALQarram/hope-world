import { useMutation } from '@tanstack/react-query'
import { useNavigate } from 'react-router-dom'
import { registerStudent } from '../api/studentEntryApi'
import { useStudentEntryStore } from '../store/useStudentEntryStore'

/**
 * Mutation for registering a new student.
 * On success: stores auth response + selected avatar in Zustand and navigates to Hope World.
 */
export function useStudentRegister() {
  const navigate = useNavigate()
  const setAuth = useStudentEntryStore((s) => s.setAuth)

  return useMutation({
    mutationFn: registerStudent,
    onSuccess: (data) => {
      setAuth(data)
      navigate('/world-map')
    },
  })
}
