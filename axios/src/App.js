import './App.css';
import GetData from './GetData';
import GetSingleData from './GetSingleData';

function App() {
  return (
    <div className="App">
      <header className="App-header">
        <GetData />
        <GetSingleData />
      </header>
    </div>
  );
}

export default App;
