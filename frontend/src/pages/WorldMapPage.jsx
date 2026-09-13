import { Link } from 'react-router-dom'
import { Lock, Lightbulb, Headphones } from 'lucide-react'
import Layout from '../components/Layout'
import mapImg from '../assets/map.png'
import { useStudentEntryStore } from '../features/student-entry/store/useStudentEntryStore'

const UNLOCKED_ISLANDS = [
  {
    id: 'academic',
    label: 'Go to Academic Island',
    to: '/academic',
    areaClassName:
      'left-[3%] top-[15%] h-[39%] w-[41%] [clip-path:polygon(18%_0,38%_2%,48%_15%,68%_18%,86%_32%,100%_51%,95%_74%,82%_92%,58%_100%,28%_96%,9%_80%,0_54%,5%_25%)]',
  },
  {
    id: 'computer',
    label: 'Go to Computer Island',
    to: '/computer',
    areaClassName:
      'right-[3%] top-[15%] h-[39%] w-[41%] [clip-path:polygon(18%_8%,44%_0,72%_8%,91%_27%,100%_51%,95%_75%,81%_92%,55%_100%,27%_95%,8%_80%,0_57%,4%_34%)]',
  },
]

const LOCKED_ISLANDS = [
  {
    id: 'therapy',
    name: 'Therapy',
    areaClassName:
      'left-[4%] top-[52%] h-[42%] w-[38%] [clip-path:polygon(29%_0,63%_2%,84%_19%,97%_40%,95%_64%,79%_86%,58%_98%,26%_93%,8%_74%,0_50%,7%_29%,18%_12%)]',
  },
  {
    id: 'arts',
    name: 'Arts & Music',
    areaClassName:
      'left-[59%] top-[54%] h-[42%] w-[38%] [clip-path:polygon(37%_0,68%_5%,89%_14%,100%_33%,97%_57%,82%_81%,53%_98%,21%_88%,3%_67%,0_38%,5%_19%,21%_2%)]',
  },
]

const RING_RADIUS = 18
const RING_CIRCUMFERENCE = 2 * Math.PI * RING_RADIUS

function ProgressRing({ percent }) {
  const offset = RING_CIRCUMFERENCE - (percent / 100) * RING_CIRCUMFERENCE

  return (
    <div className="relative size-11 shrink-0">
      <svg className="size-full -rotate-90" viewBox="0 0 44 44" aria-hidden="true">
        <circle className="fill-none stroke-border-light [stroke-width:3.5]" cx="22" cy="22" r={RING_RADIUS} />
        <circle
          className="fill-none stroke-brand-blue [stroke-linecap:round] [stroke-width:3.5] transition-[stroke-dashoffset] duration-500"
          cx="22"
          cy="22"
          r={RING_RADIUS}
          strokeDasharray={RING_CIRCUMFERENCE}
          strokeDashoffset={offset}
        />
      </svg>
      <span className="absolute inset-0 flex items-center justify-center text-[0.65rem] font-bold text-brand-blue" aria-hidden="true">
        {percent}%
      </span>
    </div>
  )
}

export default function WorldMapPage() {
  const studentName = useStudentEntryStore((s) => s.auth?.studentName)
  const unlockedCount = UNLOCKED_ISLANDS.length
  const totalCount = UNLOCKED_ISLANDS.length + LOCKED_ISLANDS.length
  const progressPercent = Math.round((unlockedCount / totalCount) * 100)

  return (
    <Layout>
      <div className="mx-auto flex max-w-6xl flex-wrap items-center justify-between gap-4 px-4 py-5 sm:px-6">
        <div className="flex items-center gap-3.5">
          <div className="relative flex size-14 shrink-0 items-center justify-center rounded-full bg-linear-to-br from-brand-blue to-brand-pink text-2xl shadow-[0_2px_8px_rgba(56,182,255,0.25)]" aria-hidden="true">
            🧭
            <span className="absolute -bottom-1 left-1/2 -translate-x-1/2 whitespace-nowrap rounded-md bg-brand-blue px-1.5 py-px text-[0.6rem] font-bold tracking-[0.02em] text-white">Guide</span>
          </div>
          <div>
            <h2 className="m-0 text-base leading-[1.3] font-bold text-brand-navy">{studentName ? `مرحباً يا ${studentName}! ✨` : 'Marhaban, Explorer! ✨'}</h2>
            <p className="mt-0.5 text-[0.8rem] leading-[1.4] text-text-secondary">
              Welcome to <span className="font-semibold text-brand-blue">Academic Island</span>!
              Choose your next learning quest below.
            </p>
          </div>
        </div>

        <div
          className="flex items-center gap-3 rounded-lg border border-border-light bg-bg-card px-4 py-2.5 shadow-soft"
          role="status"
          aria-label={`${unlockedCount} of ${totalCount} islands unlocked`}
        >
          <ProgressRing percent={progressPercent} />
          <div className="text-left">
            <span className="block text-[0.65rem] font-semibold tracking-[0.05em] text-text-muted uppercase">Island Status</span>
            <span className="block text-[0.95rem] leading-[1.3] font-bold text-brand-navy">
              {unlockedCount} of {totalCount} Unlocked
            </span>
          </div>
          <div className="flex gap-1.5" aria-hidden="true">
            <span className="flex size-6 items-center justify-center rounded-full bg-brand-yellow text-brand-navy" title="Unlocked">
              <Lightbulb size={14} />
            </span>
            <span className="flex size-6 items-center justify-center rounded-full bg-border-light text-text-muted" title="Locked">
              <Headphones size={14} />
            </span>
          </div>
        </div>
      </div>

      <section className="mx-auto max-w-6xl px-4 pb-8 sm:px-6 sm:pb-10" aria-label="World Map">
        <div className="relative overflow-hidden rounded-xl border-[3px] border-border-card bg-[#a8d8ff] shadow-card">
          <img
            src={mapImg}
            alt="Hope World map showing four islands: Academic, Computer, Therapy, and Arts & Music"
            className="block h-auto w-full"
          />

          {UNLOCKED_ISLANDS.map((island) => (
            <Link
              key={island.id}
              to={island.to}
              className={`absolute z-10 block cursor-pointer border-[3px] border-transparent transition-[border-color,box-shadow,transform] duration-200 ease-out hover:scale-[1.015] hover:border-brand-blue/50 hover:shadow-glow-blue focus-visible:scale-[1.015] focus-visible:border-brand-blue/60 focus-visible:shadow-glow-blue focus-visible:outline-3 focus-visible:outline-brand-yellow focus-visible:outline-offset-2 ${island.areaClassName}`}
              aria-label={island.label}
            />
          ))}

          {LOCKED_ISLANDS.map((island) => (
            <div
              key={island.id}
              className={`pointer-events-none absolute z-10 flex items-center justify-center bg-brand-navy/25 backdrop-brightness-75 backdrop-saturate-50 ${island.areaClassName}`}
              aria-hidden="true"
              role="presentation"
            >
              <div className="flex size-7 items-center justify-center rounded-full bg-slate-950/55 text-white/90 shadow-sm backdrop-blur-[2px] sm:size-10">
                <Lock className="size-3.5 sm:size-5" />
              </div>
            </div>
          ))}
        </div>
      </section>
    </Layout>
  )
}
