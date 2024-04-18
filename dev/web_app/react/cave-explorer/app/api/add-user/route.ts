import { sql } from "@vercel/postgres";
import { url } from "inspector";
// import { redirect } from "next/dist/server/api-utils";
import { redirect } from 'next/navigation'
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

    const result = await sql`INSERT INTO users (name, email, password) VALUES (${userName}, ${email}, ${hashedPass});`; 
    redirect('/pages/dashboard/login')
    return NextResponse.json({ result }, { status: 200 });
    
   } catch (error) {
    return NextResponse.json( { error }, { status: 500 });
   }
}