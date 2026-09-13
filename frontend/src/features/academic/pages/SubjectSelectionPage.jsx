import { Link } from 'react-router-dom'
import { ArrowLeft, GraduationCap, Loader2 } from 'lucide-react'
import Layout from '../../../components/Layout'
import SubjectCard from '../components/SubjectCard'
import { useSubjects } from '../hooks/useSubjects'

export default function SubjectSelectionPage() {
  const { subjects, isLoading, isError } = useSubjects()

  return (
    <Layout>
      <div className="mx-auto max-w-5xl px-4 sm:px-6 pb-10">
        {/* ── Back Navigation ── */}
        <div className="pt-4 pb-2">
          <Link
            to="/world-map"
            className="inline-flex items-center gap-1.5 rounded-full border border-border-light bg-bg-card px-3.5 py-1.5 text-xs font-semibold text-brand-blue shadow-soft transition-colors hover:bg-brand-blue/5 hover:border-brand-blue/30"
          >
            <ArrowLeft size={14} />
            Back to Island Map
          </Link>
        </div>

        {/* ── Page Header ── */}
        <div className="pt-6 pb-8 text-center">
          {/* Context badge */}
          <div className="flex justify-center mb-3">
            <span className="inline-flex items-center gap-1.5 rounded-full bg-brand-blue/10 px-4 py-1.5 text-xs font-bold tracking-wide text-brand-blue uppercase">
              <GraduationCap size={14} />
              Academic Island • Grade 1–3
            </span>
          </div>

          {/* Heading */}
          <h1 className="text-3xl sm:text-4xl font-extrabold text-brand-navy tracking-tight m-0">
            Choose Your{' '}
            <span className="text-brand-blue">Ad</span>
            <span className="text-brand-yellow">ven</span>
            <span className="text-brand-pink">ture</span>
            <span className="text-brand-navy">!</span>
          </h1>

          {/* Description */}
          <p className="mt-3 text-sm sm:text-base text-text-secondary max-w-xl mx-auto leading-relaxed">
            Pick a language path to explore exciting stories, animated letters,
            and spark treasure chests!
          </p>
        </div>

        {/* ── Subject Grid ── */}
        {isLoading && (
          <div className="flex flex-col items-center justify-center py-20 gap-3">
            <Loader2 size={32} className="text-brand-blue animate-spin" />
            <p className="text-sm text-text-muted font-medium">Loading subjects…</p>
          </div>
        )}

        {isError && (
          <div className="text-center py-16">
            <p className="text-brand-pink font-semibold text-lg mb-2">
              Oops! Something went wrong 😥
            </p>
            <p className="text-text-secondary text-sm">
              We couldn't load the subjects. Please try again later.
            </p>
          </div>
        )}

        {!isLoading && !isError && subjects.length === 0 && (
          <div className="text-center py-16">
            <p className="text-brand-navy font-semibold text-lg mb-2">
              No subjects available yet! 📚
            </p>
            <p className="text-text-secondary text-sm">
              Check back soon — new adventures are being prepared.
            </p>
          </div>
        )}

        {!isLoading && !isError && subjects.length > 0 && (
          <div className="grid grid-cols-1 lg:grid-cols-2 gap-6">
            {subjects.map((subject) => (
              <SubjectCard key={subject.id} subject={subject} />
            ))}
          </div>
        )}
      </div>
    </Layout>
  )
}
