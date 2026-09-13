import { useMutation } from '@tanstack/react-query'
import { useNavigate } from 'react-router-dom'
import { loginStudent } from '../api/studentEntryApi'
import { useStudentEntryStore } from '../store/useStudentEntryStore'

/**
 * Mutation for logging in an existing student.
 * On success: stores auth response in Zustand and navigates to Hope World.
 */
export function useStudentLogin() {
  const navigate = useNavigate()
  const setAuth = useStudentEntryStore((s) => s.setAuth)

  return useMutation({
    mutationFn: loginStudent,
    onSuccess: (data) => {
      setAuth(data)
      navigate('/')
    },
  })
}
