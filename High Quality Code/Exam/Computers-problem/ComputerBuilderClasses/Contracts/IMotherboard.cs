namespace ComputerBuilderClasses.Contracts
{
    /// <summary>
    /// A Motherboard interface which allows the user to access the RAM and Video Card modules.
    /// </summary>
    public interface IMotherboard
    {
        /// <summary>
        /// Loads the previously save value from the RAM
        /// </summary>
        /// <returns>The previously saved integer value</returns>
        int LoadRamValue();

        /// <summary>
        /// Saves a value in the RAM for later use
        /// </summary>
        /// <param name="value">The integer value to save</param>
        void SaveRamValue(int value);

        /// <summary>
        /// Access the video card for screen rendering purposes.
        /// </summary>
        /// <param name="data">The data to render.</param>
        void DrawOnVideoCard(string data);
    }
}