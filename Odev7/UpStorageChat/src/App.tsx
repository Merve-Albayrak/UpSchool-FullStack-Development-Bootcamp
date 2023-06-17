import  { useEffect, useState } from 'react';
import * as signalR from '@microsoft/signalr';

const ChatScreen = () => {
    const [connection, setConnection] = useState<signalR.HubConnection | null>(null);
    const [messages, setMessages] = useState<Message[]>([]);
    const [inputMessage, setInputMessage] = useState('');
    const [username, setUsername] = useState('');

    useEffect(() => {
        const newConnection = new signalR.HubConnectionBuilder()
            .withUrl('https://localhost:7054/Hubs/ChatHub')
            .withAutomaticReconnect()
            .build();

        setConnection(newConnection);
    }, []);

    useEffect(() => {
        if (connection) {
            connection.start().then(() => {
                console.log('Connected to the hub');
            });

            connection.on('ReceiveMessage', (username: string, message: string) => {
                const newMessage: Message = {
                    userName: username,
                    content: message,
                    createdOn: new Date(),
                };
                setMessages((prevMessages) => [...prevMessages, newMessage]);
            });
        }
    }, [connection]);

    const joinChatRoom = async () => {
        if (connection) {
            await connection.invoke('JoinChatRoom', 'your-room-id');
        }
    };

    const sendMessage = async () => {
        if (connection && inputMessage !== '') {
            await connection.invoke('SendMessage', username, inputMessage);
            setInputMessage('');
        }
    };

    return (
        <div style={{ maxWidth: '600px', margin: '0 auto' }}>
            <div style={{ display: 'flex', alignItems: 'center', marginBottom: '10px' }}>
                <label style={{ marginRight: '10px' }}>Username:</label>
                <input type="text" value={username} onChange={(e) => setUsername(e.target.value)} style={{ padding: '5px' }} />
                <button onClick={joinChatRoom} style={{ padding: '5px', marginLeft: '10px' }}>Join Chat Room</button>
            </div>
            <div style={{ height: '300px', overflowY: 'scroll', marginBottom: '10px', border: '1px solid #ccc', padding: '10px' }}>
                {messages.map((message, index) => (
                    <div key={index} style={{ marginBottom: '5px' }}>
                        <strong>{message.userName}: </strong>
                        {message.content}
                    </div>
                ))}
            </div>
            <div style={{ display: 'flex', alignItems: 'center' }}>
                <input type="text" value={inputMessage} onChange={(e) => setInputMessage(e.target.value)} style={{ padding: '5px' }} />
                <button onClick={sendMessage} style={{ padding: '5px', marginLeft: '10px' }}>Send Message</button>
            </div>
        </div>
    );
};

export default ChatScreen;

interface Message {
    userName: string;
    content: string;
    createdOn: Date;
}