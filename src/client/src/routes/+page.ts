export const load = async ({ fetch }) => {
    const res = await fetch('http://localhost:5166/events');
    const events = await res.json();

    return { events };
};
