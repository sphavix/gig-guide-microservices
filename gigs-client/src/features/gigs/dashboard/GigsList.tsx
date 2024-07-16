import React from 'react';
import { Gig } from '../../../app/models/gig';
import { Button, Item, Label, Segment } from 'semantic-ui-react';

interface Props {
    gigs: Gig[];
    selectGig: (id: string) => void;
}

export default function GigsList({gigs, selectGig}: Props){
    return (
        <Segment>
            <Item.Group divided>
                {gigs.map((gig) => (
                    <Item key={gig.id}>
                        <Item.Image size='tiny' circular src='/assets/user.png' />
                        <Item.Content>
                            <Item.Header as='a'>{gig.title}</Item.Header>
                            <Item.Meta>{gig.date}</Item.Meta>
                            <Item.Description>
                                {gig.description}
                                {gig.city}, {gig.venue}
                            </Item.Description>
                            <Item.Extra>
                                <Button onClick={() => selectGig(gig.id)} floated='right' content='View' color='blue' />
                                <Label basic content={gig.category} />
                            </Item.Extra>
                        </Item.Content>
                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )
}