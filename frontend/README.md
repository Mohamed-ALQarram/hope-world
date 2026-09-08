# Hope World — Frontend

> **The child-facing, gamified client application for the Hope World educational platform, built with React 19, Vite, and Tailwind CSS.**

---

## 1. Overview

The Hope World Frontend is designed specifically for early-stage learners (children) as well as instructors and academy administrators. The application departs from traditional learning management systems by providing an immersive, island-based visual world where children learn foundational literacy in **Arabic** and **English** through multimodal media (audio pronunciation, mouth-movement video articulation, animated avatars) and hands-on gamified assessments.

The client adheres to a **zero-friction, privacy-first access model**: children access their coursework simply by selecting their class and choosing a playful avatar without requiring accounts or credentials.

---

## 2. Technology Stack

| Layer / Concern | Technology | Purpose & Usage |
| :--- | :--- | :--- |
| **Core Framework** | **React 19** + **Vite 8** | Modern UI library with ultra-fast Hot Module Replacement (HMR) and optimized build bundling. |
| **Styling & Design System** | **Tailwind CSS v4** (`@tailwindcss/vite`) | Utility-first CSS framework customized with brand tokens, rounded playful shapes, and smooth transitions. |
| **Routing** | **React Router v7** (`react-router-dom`) | Declarative client-side routing across World Map, Island hubs, Lessons, Quizzes, and Management views. |
| **Server State & Caching** | **TanStack React Query v5** | Remote data fetching, aggressive caching, optimistic updates, and background synchronization. |
| **Client & UI State** | **Zustand v5** | Lightweight client-side store for session state (active class, chosen avatar), UI state, and interactive quiz mechanics. |
| **HTTP Client** | **Axios** | Centralized API client with request/response interceptors, error handling, and offline awareness. |
| **Form Handling & Validation** | **React Hook Form** + **Yup** | Lightweight form orchestration and schema-based validation for inputs and administrative forms. |
| **Educational Media** | **Native HTML5 `<audio>` & `<video>`** | Dedicated, low-latency playback of clear pronunciation recordings and lip-movement demonstration videos. |
| **Game Sounds & FX** | **Howler.js** | Low-overhead audio engine for gamified feedback (chimes, button clicks, star rewards, celebrations). |
| **Offline Persistence** | **Dexie.js** (IndexedDB) + `dexie-react-hooks` | Client-side database caching lessons and queuing offline quiz attempts for seamless syncing. |
| **Progressive Web App** | **Vite PWA Plugin** (`vite-plugin-pwa`) | Service worker caching, offline asset availability, and installable web app experience. |
| **Icons & Visuals** | **Lucide React** | Clean, accessible vector icons adapted for child-friendly interfaces. |

---

## 3. Core Features & User Flows

```
 ┌─────────────────┐       ┌─────────────────┐       ┌─────────────────┐
 │ World Map View  │ ----> │ Academic Island │ ----> │ Subject & Level │
 │ (Overworld Hub) │       │ (Arabic/English)│       │ (Lesson/Quiz)   │
 └─────────────────┘       └─────────────────┘       └─────────────────┘
```

### 1. Interactive World Map & Exploration
- Visual exploration of themed islands (starting with **Academic Island**, architected to support future **Computer Island** and **Music Island**).
- Dynamic navigation that presents educational domains as physical locations rather than standard text menus.

### 2. Frictionless Class-Based Onboarding
- **Zero-Password Entry:** Children select their assigned class from a visual selector or code entry.
- **Session Avatar & Nickname:** Children personalize their learning session with friendly animal/character avatars and a display name without creating persistent PII records.

### 3. Multimodal Lesson Player
- **Dynamic Content Rendering:** Renders lessons from structured schemas without hardcoded lesson logic.
- **Natural Phonics & Audio:** High-quality audio player providing clear, non-robotic pronunciation.
- **Pronunciation Video Demonstration:** Video integration showing mouth, lip, and tongue placement for accurate language acquisition.
- **Character/Avatar Guided Learning:** Animated visual cues that illustrate letter roots, compounding words, and sentences.

### 4. Interactive Quiz Engine
Supports 4 core interactive question formats:
- **Drag and Drop:** Sorting letters, vowels, or vocabulary into correct drop zones.
- **Matching:** Connecting pairs (letters to sounds, words to illustrations, upper to lower case).
- **Choose (Multiple Choice):** Tap-to-select visual and auditory challenges.
- **Typing / Guided Input:** Simple keyboard-driven or virtual-key spelling challenges.
- **Non-Punitive Retries & Immediate Feedback:** Encouraging animations, sound effects, and the ability to retry freely to build mastery.

### 5. Bilingual RTL & LTR Architecture
- Native support for **Right-to-Left (Arabic)** and **Left-to-Right (English)**.
- Proper bidirectional handling of text direction, layout flow, progress bar orientation, and navigation controls.

### 6. Offline Support & Sync Engine
- Automatic caching of visited curriculum content via Dexie (IndexedDB) and PWA service workers.
- Offline submission queue: quiz attempts completed without network connectivity are safely stored and synced automatically once connection is re-established.

### 7. Instructor & Manager Views
- **Instructor Controls:** Ability for authenticated teachers to select and activate the current curriculum level for their classes.
- **Manager Dashboard:** High-level overview of class performance benchmarks, completion rates, and curriculum progression over the academic year.

---

## 4. Frontend Architecture & Directory Layout

The codebase follows a **Feature-Based Architecture**, keeping business logic localized to its domain while sharing common design system primitives:

```
src/
├── assets/                 # Static branding, world map SVGs, mascot illustrations
├── components/             # Reusable design system primitives (Buttons, Cards, Modals)
├── features/               # Domain-specific business logic and interfaces
│   ├── academic/           # Academic Island, subject selection, level progression
│   │   ├── api/            # TanStack Query hooks & feature endpoints
│   │   ├── components/     # Subject cards, level maps, lesson viewers
│   │   ├── hooks/          # Custom stateful hooks (e.g. useSubjects)
│   │   ├── store/          # Academic session state
│   │   └── utils/          # Theme mappings and subject helpers
│   ├── quiz/               # Interactive Quiz Engine (Drag & drop, matching, etc.)
│   ├── session/            # Student onboarding, avatar picker, class selection
│   └── dashboard/          # Instructor level control & manager analytics
├── hooks/                  # Global custom React hooks (audio player, viewport, RTL)
├── pages/                  # Top-level page routes (WorldMapPage, SubjectPage, etc.)
├── routes/                 # React Router route definitions and guards
├── services/               # Axios instance, API client configuration, Dexie DB
├── store/                  # Global Zustand stores (sessionStore, uiStore)
└── utils/                  # Localization helpers, formatters, audio utilities
```

### Data Flow & State Segregation
```
UI Component
  └── Custom Hook
        ├── Zustand (Session / UI state)
        └── Feature API
              └── TanStack React Query (Server caching & syncing)
                    └── Axios Client (REST API) / Dexie (Offline cache)
```

---

## 5. Design System & Palette

Hope World follows a curated, child-friendly visual direction designed to feel playful, modern, and friendly:

### Brand Color Palette
- **Navy (`#24334A`):** Anchor color for high-contrast text, borders, and stable backgrounds.
- **Pink (`#FF5E7E`):** Energetic accent for interactive triggers, hearts, and highlights.
- **Yellow (`#FFD13B`):** Warm rewarding color for stars, coins, badges, and celebration banners.
- **Blue (`#38B6FF`):** Friendly sky tone for primary navigation, water elements, and cards.

### Core UX Rules
- **Oversized Touch Targets:** Generous padding and minimum 48px interactive boundaries for tablets and touch screens.
- **High Visual Affordance:** Clear, distinct states for hover, active, disabled, success, and error.
- **Cognitive Clarity:** Minimal clutter, prominent visual anchors, and low reading overhead for child learners.

---

## 6. Scripts & Development

### Prerequisites
- **Node.js**: `v20+` or `v22+` recommended
- **npm**: `v10+`

### Available Commands

```bash
# Install dependencies
npm install

# Start local development server with HMR
npm run dev

# Run ESLint validation
npm run lint

# Build production bundle
npm run build

# Preview production build locally
npm run preview
```
