import { useEffect, useState } from 'react';
import './App.css';
import { Dog } from './Models/dog.model';
import axios from 'axios';

const URL = 'http://localhost:5072';

const App = () => {

  const [dogs, setDogs] = useState<Dog[]>([]);

  useEffect(() => {
    fetch(`${URL}/dogs`)
      .then(x => x.text())
      .then(data => {
        debugger;
        setDogs(JSON.parse(data) as Dog[]);
      })
  }, [dogs]);

  debugger

  return (
    <div>
      <div className="App">
          {dogs.map((dog, i) => (<div className='dog' key={i}>{ dog.name} { dog.age } { dog.description }</div>))}
      </div>

      <div><button onClick={() => {

        const dog = {
          name: 'Bon',
          age: 5,
          description: 'Some description description description description description',
          info: 'Bon (From Site) is the most beautiful dog in the  world world worldworldworldworldworldworld',
          dateOfBorn: '2018-01-12T00:00:00'
        } as Dog;

        axios.post<Dog>(`${URL}/dogs`, dog)
          .then((response) => {
            console.log(response);
          })
      }} >Add Dog</button></div>
    </div>
  );
}

export default App;
