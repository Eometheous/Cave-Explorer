import asyncpg
import psycopg2
from bcrypt import checkpw
import bcrypt
from flask import Flask, jsonify, request
from dotenv import load_dotenv
import os

def connect_to_database():
    load_dotenv()
    return psycopg2.connect(
        database=os.getenv('POSTGRES_DATABASE'),
        user=os.getenv('POSTGRES_USER'),
        password=os.getenv('POSTGRES_PASSWORD'),
        host=os.getenv('POSTGRES_HOST')
    )

def fetch_user(email):
    connection = connect_to_database()
    cursor = connection.cursor()
    cursor.execute("SELECT * FROM users WHERE email='{0}'".format(email))
    user = cursor.fetchone()
    connection.commit()
    cursor.close()
    connection.close()
    return user

def login():
    
    email = 'jonathan.sthomas@icloud.com'
    password = '1234'

    try:
        if not email or not password:
            print('Email and password are required')
        
        user = fetch_user(email)
        print(user)
        if not user:
            print('Email or password is incorrect')
        
        password_match = checkpw(password.encode('utf-8') , user[3].encode('utf-8'))

        if not password_match:
            print('Email or password is inccorect')
        
        print("Found user")
        # return jsonify({
        #     'success': True,
        #     'message': 'Login succesful',
        #     'user:': {
        #         'email': user['email'],
        #         'level': user['level']
        #     }
        # }), 200
    
    except Exception as e:
        print(e)

if __name__ == "__main__":
    login()