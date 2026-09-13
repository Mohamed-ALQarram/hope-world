import { create } from 'zustand'
import { persist } from 'zustand/middleware'

/**
 * Client-side state for the student entry / onboarding flow.
 *
 * Persisted fields (and only these):
 *   selectedClass  → { classId, className }
 *   auth           → { studentId, studentName, classId, className, token }
 *   selectedAvatar → string key (frontend-only, not sent to backend)
 */
export const useStudentEntryStore = create(
  persist(
    (set) => ({
      selectedClass: null,
      auth: null,
      selectedAvatar: null,

      setSelectedClass: (cls) =>
        set({
          selectedClass: { classId: cls.classId, className: cls.className },
        }),

      setAuth: (data) =>
        set({
          auth: {
            studentId: data.studentId,
            studentName: data.studentName,
            classId: data.classId,
            className: data.className,
            token: data.token,
          },
        }),

      setSelectedAvatar: (avatarKey) => set({ selectedAvatar: avatarKey }),

      clearEntry: () =>
        set({ selectedClass: null, auth: null, selectedAvatar: null }),
    }),
    {
      name: 'student-entry-store',
    },
  ),
)
