<script lang="ts">
    export let data;

    let title = data.event.title;
    let categoryName = data.event.categoryName;

    async function save() {
        await fetch(`http://localhost:5166/events/${data.event.id}`, {
            method: 'PUT',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ title, categoryName })
        });

        window.location.href = '/';
    }
    
    async function back() {

        window.location.href = '/';
    }
    
    async function remove() {
        if (!confirm('Are you sure you want to delete this event?')) {
            
            return;
        }

        await fetch(`http://localhost:5166/events/${data.event.id}`, {
            method: 'DELETE'
        });

        window.location.href = '/';
    }


</script>

<div class="page">
    <h1>Edit event</h1>

    <form on:submit|preventDefault={save} class="card">
        <label>
            Title
            <input bind:value={title} />
        </label>

        <label>
            Category
            <input bind:value={categoryName} />
        </label>

        <button type="submit">Save</button>

        <hr />
        <button type="button" on:click={back}>Return</button>
        <button type="button" class="danger" on:click={remove}>
            Delete event
        </button>
    </form>
</div>

<style type="text/css">
    .page {
        max-width: 500px;
        margin: 2rem auto;
    }

    .card {
        padding: 1.5rem;
        border: 1px solid #ddd;
        border-radius: 6px;
        display: flex;
        flex-direction: column;
        gap: 1rem;
    }

    label {
        display: flex;
        flex-direction: column;
        gap: 0.25rem;
    }

    input {
        padding: 0.5rem;
    }

    button {
        padding: 0.6rem;
        cursor: pointer;
    }

    button.danger {
        background: #c62828;
        color: white;
        border: none;
    }

</style>
