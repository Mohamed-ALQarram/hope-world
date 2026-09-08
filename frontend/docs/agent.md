# Hope World — Agent Rules

## Stack
- React + Vite + JavaScript
- Tailwind CSS
- React Router
- Zustand
- TanStack Query
- Axios
- React Hook Form + Yup
- Lucide React

## Architecture
- Use feature-based architecture.
- Keep business logic inside the relevant feature.
- Put genuinely reusable UI in shared components.
- TanStack Query = server state.
- Zustand = client/UI state.
- Prefer simple solutions; avoid unnecessary abstractions and dependencies.

## Product Rules
- Do not invent business requirements.
- Do not change existing behavior unless required.
- Student-facing UI must remain child-friendly and gamified.
- Arabic and English must support RTL/LTR correctly.
- Keep the Hope World visual identity consistent.

## Media
- Use native <audio> and <video> for educational media.
- Howler is for game/audio effects, not basic media playback.
- Follow the offline/media rules in `docs/architecture.md`.

## Workflow
Before coding:
1. Inspect the existing implementation.
2. Reuse existing patterns/components.
3. Make the smallest clean change.
4. Run lint/build after changes.

Read the relevant docs before making architectural, UI, API, or product decisions.