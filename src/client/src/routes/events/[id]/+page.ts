export const load = async ({ params, fetch }) => {
    const res = await fetch(`http://localhost:5166/events/${params.id}`);
    const event = await res.json();

    return { event };
};
