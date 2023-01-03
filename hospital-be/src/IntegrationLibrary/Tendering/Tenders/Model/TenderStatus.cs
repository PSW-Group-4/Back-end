namespace IntegrationLibrary.Tendering.Model
{
    /*
     * Active: Tender is active and accepting applications.
     * Expired: Tender's deadline has expired. No winners.
     * Pending winner confirmation: A winner has been chosen and needs to accept the offer.
     * Completed: The winner has accepted the offer and the tender has been completed successfully.
     * Failed: The winner hasn't accepted the offer and the tender has failed.
     */
    public enum TenderStatus
    {
        ACTIVE,
        EXPIRED,
        PENDING_WINNER_CONFIRMATION,
        COMPLETED,
        FAILED
    }
}