import './App.css';
import GetData from './GetData';
import GetSingleData from './GetSingleData';
import UpdateData from './UpdateData';
import PostData from './PostData';


function App() {
  return (
    <div className="App">
      <header className="App-header">
        <GetData />
        <GetSingleData />
        <UpdateData />
        <PostData />
      </header>
    </div>
  );
}

export default App;
