<script lang="ts">
    export let data;
</script>

<div class="page">
    <div class="header">
        <h1>Events</h1>
        <a href="/add-event" class="add-link">＋ Add</a>
    </div>
    <div class="card">

        <ul class="event-list">
            {#each data.events as event}
                <li class="event-row">
                    <span>{event.title}</span>
                    <a class="link" href={`/events/${event.id}`} title="Edit">⋮</a>
                </li>
            {/each}
        </ul>
    </div>
</div>
<style type="text/css">
    .header {
        display: flex;
        justify-content: space-between;
        align-items: center;
    }

    .add-link {
        text-decoration: none;
        font-size: 0.9rem;
        opacity: 0.7;
    }

    .add-link:hover {
        opacity: 1;
    }

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

    .event-list {
        list-style: none;
        padding: 0;
        margin: 0;
    }

    .event-row {
        display: flex;
        justify-content: space-between;
        align-items: center;
        padding: 0.25rem 0;
    }

    .link {
        text-decoration: none;
        opacity: 0.4;
        cursor: pointer;
    }

    .event-row:hover .link {
        opacity: 1;
    }

</style>