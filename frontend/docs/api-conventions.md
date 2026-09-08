# Hope World — API Conventions

## Rules

- Use the shared Axios client.
- Keep API calls inside feature-level API modules.
- Use TanStack Query for server-state access.
- Keep query keys consistent.
- Handle loading, error, and empty states.

## Naming

Queries:
- use<Class>()
- useStudents()
- useStudentProgress()

Mutations:
- useCreateStudent()
- useSubmitQuiz()

API modules:
- classApi.js
- studentApi.js
- quizApi.js
- progressApi.js

## Responses

Prefer consistent API response shapes.

Do not introduce endpoint conventions that conflict with existing backend APIs.