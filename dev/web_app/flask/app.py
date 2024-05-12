import asyncpg
from bcrypt import checkpw
import bcrypt
from flask import Flask, jsonify, request
from dotenv import load_dotenv
import os

app = Flask(__name__)
async def connect_to_database():
    load_dotenv()
    return await asyncpg.connect(
        database=os.getenv('POSTGRES_DATABASE'),
        user=os.getenv('POSTGRES_USER'),
        password=os.getenv('POSTGRES_PASSWORD'),
        host=os.getenv('POSTGRES_HOST')
    )

async def fetch_user(email):
    connection = connect_to_database()
    user = await connection.fetchrow("SELECT * FROM users WHERE email = %s", email)
    await connection.close()
    return user

@app.route("/user/sign-up", methods=['POST'])
async def sign_up():
    connection = connect_to_database()
    if request.method == 'POST':
        email = request.form['email']
        username = request.form['username']
        password = request.form['password']
        cursor = connection.cursor()
        bytes = password.encode('utf-8') 
        salt = bcrypt.gensalt() 
        hash = bcrypt.hashpw(bytes, salt) 
        cursor.execute("INSERT INTO users (name, email, password) VALUES (%s, %s, %s)", (username, email, hash))
        connection.commit()
        cursor.close()
    return jsonify({
            'success': True,
            'message': 'Succesful'
        }), 200

@app.route("/user/login", methods=['POST'])
async def login():
    data = request.json
    
    email = data.get('email')
    password = data.get('password')

    try:
        if not email or not password:
            raise ValueError('Email and password are required')
        
        user = await fetch_user(email)

        if not user:
            raise ValueError('Email or password is incorrect')
        
        password_match = checkpw(password.encode('utf-8'), user['password'].encode('utf-8'))

        if not password_match:
            raise ValueError('Email or password is inccorect')
        
        return jsonify({
            'success': True,
            'message': 'Login succesful',
            'user:': {
                'email': user['email'],
                'level': user['level']
            }
        }), 200
    
    except Exception as e:
        return jsonify({
            'success': False,
            'message': str(e)
        }), 401


if __name__ == '__main__':
    app.run(debug=True, port=8080)