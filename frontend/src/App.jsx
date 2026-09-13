import { Routes, Route } from 'react-router-dom'
import WorldMapPage from './pages/WorldMapPage'
import SubjectSelectionPage from './features/academic/pages/SubjectSelectionPage'
import ChooseClassPage from './pages/ChooseClassPage'
import ChooseStudentPage from './pages/ChooseStudentPage'
import CreateStudentPage from './pages/CreateStudentPage'

function App() {
  return (
    <Routes>
      <Route path="/" element={<WorldMapPage />} />
      <Route path="/academic" element={<SubjectSelectionPage />} />
      <Route path="/academic/:subjectId" element={<PlaceholderPage title="Subject" />} />
      <Route path="/computer" element={<PlaceholderPage title="Computer Island" />} />
      <Route path="/student-entry" element={<ChooseClassPage />} />
      <Route path="/student-entry/choose-student" element={<ChooseStudentPage />} />
      <Route path="/student-entry/create-student" element={<CreateStudentPage />} />
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

