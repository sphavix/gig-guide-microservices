import React from 'react';
import { Button, Form, Segment } from 'semantic-ui-react';

export default function GigForm(){
    return (
        <Segment clearing>
            <Form>
                <Form.Input placeHolder='Title' />
                <Form.TextArea placeHolder='Description' />
                <Form.Input placeHolder='Category' />
                <Form.Input placeHolder='Date' />
                <Form.Input placeHolder='City' />
                <Form.Input placeHolder='Venue' />
                <Button floated='right' positive type='submit' content='Submit' />
                <Button floated='right' type='button' content='Cancel' />
            </Form>
        </Segment>
    )
}