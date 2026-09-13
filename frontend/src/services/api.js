import axios from 'axios'

const api = axios.create({
  baseURL: 'https://hopeacademy.runasp.net',
  headers: { 'Content-Type': 'application/json' },
})

/**
 * Attach the auth token (if present) to every outgoing request.
 * Reads from the Zustand persisted store in localStorage.
 */
api.interceptors.request.use((config) => {
  try {
    const raw = localStorage.getItem('student-entry-store')
    if (raw) {
      const { state } = JSON.parse(raw)
      if (state?.auth?.token) {
        config.headers.Authorization = `Bearer ${state.auth.token}`
      }
    }
  } catch {
    // localStorage unavailable or corrupt — continue without token
  }
  return config
})

export default api
