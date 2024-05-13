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

def increment_user_level(email):
    connection = connect_to_database()
    cursor = connection.cursor()
    cursor.execute("UPDATE users SET level = level + 1 WHERE email='{0}'".format(email))
    connection.commit()
    cursor.close()
    connection.close()
    
def increment_level():
    # data = request.form
    
    email = 'jonathan.sthomas@icloud.com'

    try:
        if not email:
            print("Email required")
            # raise ValueError('Email required')
        
        user = fetch_user(email)

        if not user:
            print("email not found")
            # raise ValueError('Email not found')
        
        increment_user_level(email)
        
        print({
            'success': True,
            'message': 'Increment succesful'
        })
    
    except Exception as e:
        print(e)
    
if __name__ == "__main__":
    increment_level()