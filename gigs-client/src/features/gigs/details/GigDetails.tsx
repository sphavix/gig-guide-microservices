import React from 'react';
import { Button, Card } from "semantic-ui-react";
import { Gig } from "../../../app/models/gig";

interface Props{
    gig: Gig
}


export default function GigDetails({gig}: Props){
    return (
       <Card fluid>
            <img src={`/assets/categoryImages/${gig.category}.jpg`} alt='gig' />
            <Card.Content>
                <Card.Header>{gig.title}</Card.Header>
                <Card.Meta>
                    <span>{gig.category}</span>
                </Card.Meta>
                <Card.Description>{gig.description}</Card.Description>
            </Card.Content>
            <Card.Content extra>
                <Button.Group widths='2'>
                    <Button basic color='orange' content='Edit' />
                    <Button basic color='red' content='Cancel' />
                </Button.Group>
            </Card.Content> 
            <Card.Content extra>
            </Card.Content>
       </Card>
    )
}