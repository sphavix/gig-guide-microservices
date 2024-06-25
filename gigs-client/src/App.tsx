import { useEffect, useState } from 'react'
import './App.css'
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';

function App() {
  const [gigs, setGigs] = useState([]);

  useEffect(() => {
    axios.get('http://localhost:5001/api/gigs')
        .then(respons => {
          setGigs(respons.data)
        })
  }, [])

  return (
    <div>
      <Header as='h2' icon='users' content='Local Gigs' />
      <List>
        {
          gigs.map((gig: any) => (
            <List.Item key={gig.id}>
              {gig.title}
            </List.Item>
          ))
        }
      </List>
    </div>
  )
}

export default App
