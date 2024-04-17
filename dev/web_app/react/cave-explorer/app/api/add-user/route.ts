import { sql } from "@vercel/postgres";
import { NextResponse } from "next/server";

export async function GET(request: Request) {
   const { searchParams } = new URL(request.url);
   const userName = searchParams.get('name');
   const email = searchParams.get('email');
   const password = searchParams.get('password');

   try {
    if (!userName || !email || !password) throw new Error('Username, email, and password required');
    const bcrypt = require('bcrypt');
    const hashedPass = await bcrypt.hash(password, 10);

    await sql`INSERT INTO users (name, email, password) VALUES (${userName}, ${email}, ${hashedPass});`; 
   } catch (error) {
    return NextResponse.json( { error }, { status: 500 });
   }
}