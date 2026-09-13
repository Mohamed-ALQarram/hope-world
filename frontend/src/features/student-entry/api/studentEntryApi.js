import api from '../../../services/api'

const AUTH_BASE = '/api/auth'

/** GET /api/auth/classes */
export function getClasses() {
  return api.get(`${AUTH_BASE}/classes`).then((res) => res.data)
}

/** GET /api/auth/classes/{classId}/students */
export function getStudentsByClass(classId) {
  return api.get(`${AUTH_BASE}/classes/${classId}/students`).then((res) => res.data)
}

/** POST /api/auth/login */
export function loginStudent({ classId, studentId }) {
  return api.post(`${AUTH_BASE}/login`, { classId, studentId }).then((res) => res.data)
}

/** POST /api/auth/register */
export function registerStudent({ className, studentName }) {
  return api.post(`${AUTH_BASE}/register`, { className, studentName }).then((res) => res.data)
}
