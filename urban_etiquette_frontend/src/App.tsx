import "./App.css";
import TanstackTest from "./tanstacktest";
import {
  QueryClient,
  QueryClientProvider,
} from '@tanstack/react-query'

// Create a client
const queryClient = new QueryClient()

function App() {
    return (
      <QueryClientProvider client={queryClient}>
            <div className="text-3xl font-bold underline">hello world</div>
            <TanstackTest />
        </QueryClientProvider>
    );
}

export default App;
