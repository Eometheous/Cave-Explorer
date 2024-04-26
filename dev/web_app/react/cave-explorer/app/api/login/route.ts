import { NextApiRequest, NextApiResponse } from "next";
import { NextResponse } from "next/server";
import { compare } from 'bcrypt';
import { sql } from "@vercel/postgres";

interface LoginRequestBody  {
    email: string;
    password: string;
}
export async function POST(request: Request) {
    const { searchParams } = new URL(request.url);
    const email = searchParams.get('email');
    const password = searchParams.get('password');

    try {
        if (!email || !password) throw new Error('Username, email, and password required');

        const result = await sql`SELECT * FROM users WHERE email=${email}`;

        const user = result.rows[0];

        const passwordMatch = await compare(password, user.password)

        if (user && passwordMatch) {
            return NextResponse.redirect(new URL('/pages/dashboard/', request.url))
        }
        return NextResponse.redirect(new URL('/pages/auth/login', request.url))
    } catch (error) {
        return NextResponse.redirect(new URL('/pages/auth/login', request.url))
    }
}