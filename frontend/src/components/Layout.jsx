import Header from './Header'
import Footer from './Footer'

export default function Layout({ children }) {
  return (
    <div className="min-h-svh flex flex-col bg-bg-page">
      <Header />
      <main className="flex-1">{children}</main>
      <Footer />
    </div>
  )
}
