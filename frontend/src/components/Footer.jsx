import { Smile } from 'lucide-react'

export default function Footer() {
  return (
    <footer className="bg-bg-footer border-t border-border-light mt-auto">
      <div className="max-w-6xl mx-auto px-4 sm:px-6 py-5 flex flex-col sm:flex-row items-center justify-between gap-3 text-sm">
        {/* Brand */}
        <div className="flex items-center gap-2.5">
          <div className="flex items-center justify-center w-9 h-9 rounded-full bg-brand-blue/10 text-brand-blue">
            <Smile size={20} />
          </div>
          <div className="text-left">
            <p className="font-semibold text-brand-navy leading-tight">Hope World Kids</p>
            <p className="text-text-muted text-xs leading-tight">
              Joyful, safe learning through adventure and play
            </p>
          </div>
        </div>

        {/* Copyright */}
        <p className="text-text-muted text-xs">
          © {new Date().getFullYear()} Hope World Adventures. Safe Play Certified.
        </p>
      </div>
    </footer>
  )
}
