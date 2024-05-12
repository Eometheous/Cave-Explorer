import { useState } from 'react';

export default function SignUpForm() {
    const [formData, setFormData] = useState({
        email: '',
        name: '',
        password: ''
    });

    const handleChange = (e: { target: { name: any; value: any; }; }) => {
        const { name, value } = e.target;
        setFormData(prevState => ({
            ...prevState,
            [name]: value
        }));
    };

    const handleSubmit = async (e: { preventDefault: () => void; }) => {
        e.preventDefault();
        try {
            const response = await fetch('http://127.0.0.1:8080/user/sign-up', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(formData)
            });
            if (response.ok) {
                // Handle successful form submission, e.g., show a success message
                console.log('Form submitted successfully');
            } else {
                // Handle form submission error, e.g., show an error message
                console.error('Form submission failed');
            }
        } catch (error) {
            console.error('Error submitting form:', error);
        }
    };

    return (
        <main className="flex min-h-screen flex-col items-center justify-between p-24">
            <form onSubmit={handleSubmit} className="space-y-3">
                <div className="flex-1 rounded-lg px-6 pb-4 pt-8">
                    <h1>Please enter your information below</h1>
                    <div className="w-full">
                        <div>
                            <label htmlFor="email">
                                Email
                            </label>
                            <div className="relative">
                                <input 
                                    className="text-black peer block w-full rounded-md border border-gray-200"
                                    id="email"
                                    type="email"
                                    name="email"
                                    placeholder="Enter your email address"
                                    value={formData.email}
                                    onChange={handleChange}
                                    required
                                />
                            </div>
                            <label htmlFor="name">
                                Username
                            </label>
                            <div className="relative">
                                <input 
                                    className="text-black peer block w-full rounded-md border border-gray-200"
                                    id="name"
                                    type="text"
                                    name="name"
                                    placeholder="Enter your username"
                                    value={formData.name}
                                    onChange={handleChange}
                                    required
                                />
                            </div>
                            <label htmlFor="password">
                                Password
                            </label>
                            <div className="relative">
                                <input 
                                    className="text-black peer block w-full rounded-md border border-gray-200"
                                    id="password"
                                    type="password"
                                    name="password"
                                    placeholder="Enter your password"
                                    value={formData.password}
                                    onChange={handleChange}
                                    required
                                />
                            </div>
                        </div>
                        <button type="submit" className="peer block w-full rounded-md border border-gray-200">
                            Sign up
                        </button>
                    </div>
                </div>
            </form>
        </main>
    );
}
