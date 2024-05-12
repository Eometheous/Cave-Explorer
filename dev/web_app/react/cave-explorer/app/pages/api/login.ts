import { NextApiRequest, NextApiResponse } from "next";
import { NextResponse } from "next/server";
import { compare } from 'bcrypt';
import { sql } from "@vercel/postgres";

interface LoginRequestBody  {
    email: string;
    password: string;
}
export default async function handler(req: NextApiRequest, res: NextApiResponse) {
    // if (req.method === 'POST') {
        const {email, password} = req.body as LoginRequestBody;

        try {
            if (!email || !password) throw new Error('Email and password are required');

            const result = await sql`SELECT * FROM users WHERE email=${email}`;
            const user = result.rows[0];

            if (!user) throw new Error('Email or password is inccorect');

            const passwordMatch = await compare(password, user.password);

            if (!passwordMatch) throw new Error('Email or password is inccorect');

            res.status(200).json({success: true, message: 'Login successful', user: { email: user.email, level: user.level } });
        } catch (error) {
            res.status(401).json({ success: false, message: error});
        }
    // }
    // else {
    //     res.status(405).json({ success: false, message: 'Method Not Allowed' });
    // }
}