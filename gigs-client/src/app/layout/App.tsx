import { useEffect, useState } from 'react'
import axios from 'axios';
import { Header, List } from 'semantic-ui-react';
import { Gig } from '../models/gig';

function App() {
  const [gigs, setGigs] = useState<Gig[]>([]);

  useEffect(() => {
    axios.get<Gig[]>('http://localhost:5001/api/gigs/getallgigs')
        .then(respons => {
          setGigs(respons.data)
        })
  }, [])

  return (
    <div>
      <Header as='h2' icon='users' content='Local Gigs' />
      <List>
        {
          gigs.map((gig) => (
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
