<script lang="ts">
    let title = '';
    let categoryName = '';

    async function submit() {
        await fetch('http://localhost:5166/events', {
            method: 'POST',
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify({title, categoryName})
        });

        window.location.href = '/';
    }

    async function back() {

        window.location.href = '/';
    }

</script>
<div class="page">
    <h1>Add event</h1>

    <form on:submit|preventDefault={submit} class="card">
        <div>
            <label>
                Title<br/>
                <input bind:value={title} required/>
            </label>
        </div>

        <div>
            <label>
                Category<br/>
                <input bind:value={categoryName} required/>
            </label>
        </div>

        <button type="submit">Create</button>
        <button type="button" on:click={back}>Return</button>

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
