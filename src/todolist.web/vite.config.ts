import { defineConfig, loadEnv } from 'vite'
import react from '@vitejs/plugin-react'

export default ({ mode } : { mode:string }) => {
  const defaultServerPort = '3000'
  process.env = {...process.env, ...loadEnv(mode, process.cwd())};

  return defineConfig({
    plugins: [react()],
    preview: {
      port: parseInt(process.env.VITE_SERVER_PORT || defaultServerPort)
    },
    server: {
      port: parseInt(process.env.VITE_SERVER_PORT || defaultServerPort),
      strictPort: true,
      host: true,
        origin: `http://0.0.0.0:${process.env.VITE_SERVER_PORT || defaultServerPort}`
     }
  });
}
