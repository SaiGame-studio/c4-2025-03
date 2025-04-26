using Invector.vCharacterController;

public class PlayerInput : vThirdPersonInput
{
    protected override void InitilizeController()
    {
        cc = GetComponent<vThirdPersonController>();
        PlayerController newCC = (PlayerController)cc;

        if (newCC != null)
            newCC.NewInit();
    }
}
