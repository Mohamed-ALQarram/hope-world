import { Routes, Route } from 'react-router-dom'
import WorldMapPage from './pages/WorldMapPage'
import SubjectSelectionPage from './features/academic/pages/SubjectSelectionPage'

function App() {
  return (
    <Routes>
      <Route path="/" element={<WorldMapPage />} />
      <Route path="/academic" element={<SubjectSelectionPage />} />
      <Route path="/academic/:subjectId" element={<PlaceholderPage title="Subject" />} />
      <Route path="/computer" element={<PlaceholderPage title="Computer Island" />} />
    </Routes>
  )
}

function PlaceholderPage({ title }) {
  return (
    <div className="flex items-center justify-center min-h-svh bg-bg-page">
      <div className="text-center">
        <h1 className="text-3xl font-bold text-brand-navy mb-2">{title}</h1>
        <p className="text-text-secondary">Coming soon — this island is under construction! 🏗️</p>
      </div>
    </div>
  )
}

export default App
