# Hope World — Architecture

## Frontend Structure

src/
├── assets/
├── components/
├── features/
├── hooks/
├── pages/
├── routes/
├── services/
├── store /
└── utils/

## Feature Structure

features/<feature>/
├── components/
├── hooks/
├── api/
├── store/
└── utils/

Use only folders that are actually needed.

## State

TanStack Query:
- Server data
- Fetching
- Caching
- Mutations
- Synchronization

Zustand:
- Shared client state
- UI state
- Temporary game state

React state:
- Local component state

Do not duplicate the same source of truth.

## API

Use a shared Axios instance.

Component
→ Hook
→ Feature API
→ Axios

Do not make raw API calls from UI components unless the feature is trivial.

## Media

Educational media:
- Native <audio>
- Native <video>

Game sounds:
- Howler

Do not add a media library without a concrete requirement.

## Offline

The application is expected to support offline-friendly behavior.

Use:
- IndexedDB / Dexie for structured local data
- Service Worker / PWA for application caching
- Local sync queue for offline quiz results

Backend remains the source of truth.

Local storage is an offline working copy.

## Data Model Concepts

Student has a lightweight profile without password authentication.

Progress:
- StudentSubjectProgress
- ClassSubjectProgress
- QuizAttempt
- LearningSession

Student progress is independent from class progress.

Class progress describes the shared curriculum level.

Student progress describes the exact resume position.