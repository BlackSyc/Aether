// GENERATED AUTOMATICALLY FROM 'Assets/Scripts/Input/InputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""79b777c1-44aa-4097-8732-e0c56c13042e"",
            ""actions"": [
                {
                    ""name"": ""Movement"",
                    ""type"": ""Value"",
                    ""id"": ""b8ef8154-f9c1-4122-80ed-ddbc77c4da71"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""bcce361a-cd34-40b9-bfce-ebeaf532712a"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""aaf50eed-de6a-4aa4-b4e1-9f22efcee2c4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Look"",
                    ""type"": ""Button"",
                    ""id"": ""3e3dec64-8c1a-49d2-a07a-bcbdac484b23"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Zoom"",
                    ""type"": ""Button"",
                    ""id"": ""fe7767d3-39ee-49e2-bdda-8e974e378aad"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SwapActionMap"",
                    ""type"": ""Button"",
                    ""id"": ""a037d2ed-f02d-4178-b989-9c48c7b77fa6"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CastSpell1"",
                    ""type"": ""Button"",
                    ""id"": ""90a1085d-43dd-4c6b-b422-73fc8c513769"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CastSpell2"",
                    ""type"": ""Button"",
                    ""id"": ""861e5585-0caf-4339-883e-b1e8060dac2d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CastSpell3"",
                    ""type"": ""Button"",
                    ""id"": ""97b0a94d-2299-4225-b365-3f48168ff487"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CastSpell4"",
                    ""type"": ""Button"",
                    ""id"": ""6ea75935-eaf3-4b69-bac5-6f97d9a54197"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CastSpell5"",
                    ""type"": ""Button"",
                    ""id"": ""11967b57-fdf7-4a7c-adf9-089a85e3db28"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CastSpell6"",
                    ""type"": ""Button"",
                    ""id"": ""77f7b94e-a0c3-40f2-b8ea-f73519145b68"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CastSpell7"",
                    ""type"": ""Button"",
                    ""id"": ""f998bf93-a146-4136-b121-a6a0c3dce72e"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CancelCast"",
                    ""type"": ""Button"",
                    ""id"": ""9330279e-0330-413c-8fb1-bd9046fba5c8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CastOnSelf"",
                    ""type"": ""Button"",
                    ""id"": ""442a755a-eb4e-49e9-9a82-ee942c0c1a98"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WASD"",
                    ""id"": ""2b4bbc18-1fde-41da-9c26-3dd26f04dbee"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""33512d3f-c1cd-4632-94b4-22066bd49cc9"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b690e8ae-019b-4688-b9cc-6840f32b7de9"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8bf0e21b-fbb8-4144-8ede-65d422b71c75"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""57ac4b50-b279-4458-a184-3dd48e1334dc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""94efd7e0-93f0-433e-9b2e-47551eab5a11"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""23bdd8ff-3f11-4e85-a026-f621f90ba153"",
                    ""path"": ""<Keyboard>/f"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b24fed9-c9f8-4937-a182-5d75487f1320"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Look"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1afa7ed5-a7f5-4580-92b5-05285a684c37"",
                    ""path"": ""<Mouse>/scroll"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Zoom"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""10202580-9391-40cd-8ed8-502c29984fd8"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapActionMap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""01c69e39-8d1d-4bc6-81a0-d1ffcc66bfb0"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastSpell1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0bb833ea-9908-4193-bfa4-be18e8b960e3"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CancelCast"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c6bab15-f26f-4503-8821-0db14df6a6d9"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastSpell2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5968dec2-b5e1-4543-a44c-3f6191bce869"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastSpell3"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""33b201eb-a914-4427-8690-9948696fa1d1"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastSpell4"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""92e03fe5-bf3b-4e10-8c50-a4923c095d9b"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastSpell5"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c78fda47-9721-4be5-bba9-c55d7aea68c1"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastSpell6"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9c7d1707-a7b7-4797-bb0f-a8a56846e9d8"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastSpell7"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""555df98b-6de3-4ebd-8531-8cfad80860ea"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastOnSelf"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""User Interface"",
            ""id"": ""5625ece3-9ebe-4fac-be4d-c36d80359ea4"",
            ""actions"": [
                {
                    ""name"": ""SwapActionMap"",
                    ""type"": ""Button"",
                    ""id"": ""0f0bab17-3dc9-4edc-9979-0769e0cdba7c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CastOnSelf"",
                    ""type"": ""Button"",
                    ""id"": ""1325e7cc-d894-40cc-baad-71d6973b1de8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveCursor"",
                    ""type"": ""PassThrough"",
                    ""id"": ""53ad625e-e2a9-4592-bc31-6cbf9e0e2b77"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""81a377e7-311b-4522-a39d-203e375fd68c"",
                    ""path"": ""<Keyboard>/tab"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SwapActionMap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5a1b0e99-6bb7-4b40-8708-bb0c084f48ad"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e67a0343-602e-4b36-985e-4ee22807a066"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastOnSelf"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""PopUp"",
            ""id"": ""825db8dc-d3a0-4e20-8341-7cad3ae4dd70"",
            ""actions"": [
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""54d4911f-079c-4648-9ceb-6fd399c8044d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""CastOnSelf"",
                    ""type"": ""Button"",
                    ""id"": ""8334e7ac-0db1-4c96-9fb3-d6d662a90169"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""MoveCursor"",
                    ""type"": ""PassThrough"",
                    ""id"": ""c95de62c-e76e-456c-82c1-911459ffbfdc"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""5def669c-22b6-4c7f-b67f-c5d39bd4cbdd"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1231db25-849d-4679-9a7f-f347c0334cf0"",
                    ""path"": ""<Mouse>/position"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MoveCursor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""6e3f711a-4b0f-454a-ab29-95eb446023d3"",
                    ""path"": ""<Keyboard>/ctrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""CastOnSelf"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""BaseControlScheme"",
            ""bindingGroup"": ""BaseControlScheme"",
            ""devices"": []
        }
    ]
}");
        // Player
        m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
        m_Player_Movement = m_Player.FindAction("Movement", throwIfNotFound: true);
        m_Player_Jump = m_Player.FindAction("Jump", throwIfNotFound: true);
        m_Player_Interact = m_Player.FindAction("Interact", throwIfNotFound: true);
        m_Player_Look = m_Player.FindAction("Look", throwIfNotFound: true);
        m_Player_Zoom = m_Player.FindAction("Zoom", throwIfNotFound: true);
        m_Player_SwapActionMap = m_Player.FindAction("SwapActionMap", throwIfNotFound: true);
        m_Player_CastSpell1 = m_Player.FindAction("CastSpell1", throwIfNotFound: true);
        m_Player_CastSpell2 = m_Player.FindAction("CastSpell2", throwIfNotFound: true);
        m_Player_CastSpell3 = m_Player.FindAction("CastSpell3", throwIfNotFound: true);
        m_Player_CastSpell4 = m_Player.FindAction("CastSpell4", throwIfNotFound: true);
        m_Player_CastSpell5 = m_Player.FindAction("CastSpell5", throwIfNotFound: true);
        m_Player_CastSpell6 = m_Player.FindAction("CastSpell6", throwIfNotFound: true);
        m_Player_CastSpell7 = m_Player.FindAction("CastSpell7", throwIfNotFound: true);
        m_Player_CancelCast = m_Player.FindAction("CancelCast", throwIfNotFound: true);
        m_Player_CastOnSelf = m_Player.FindAction("CastOnSelf", throwIfNotFound: true);
        // User Interface
        m_UserInterface = asset.FindActionMap("User Interface", throwIfNotFound: true);
        m_UserInterface_SwapActionMap = m_UserInterface.FindAction("SwapActionMap", throwIfNotFound: true);
        m_UserInterface_CastOnSelf = m_UserInterface.FindAction("CastOnSelf", throwIfNotFound: true);
        m_UserInterface_MoveCursor = m_UserInterface.FindAction("MoveCursor", throwIfNotFound: true);
        // PopUp
        m_PopUp = asset.FindActionMap("PopUp", throwIfNotFound: true);
        m_PopUp_Cancel = m_PopUp.FindAction("Cancel", throwIfNotFound: true);
        m_PopUp_CastOnSelf = m_PopUp.FindAction("CastOnSelf", throwIfNotFound: true);
        m_PopUp_MoveCursor = m_PopUp.FindAction("MoveCursor", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Player
    private readonly InputActionMap m_Player;
    private IPlayerActions m_PlayerActionsCallbackInterface;
    private readonly InputAction m_Player_Movement;
    private readonly InputAction m_Player_Jump;
    private readonly InputAction m_Player_Interact;
    private readonly InputAction m_Player_Look;
    private readonly InputAction m_Player_Zoom;
    private readonly InputAction m_Player_SwapActionMap;
    private readonly InputAction m_Player_CastSpell1;
    private readonly InputAction m_Player_CastSpell2;
    private readonly InputAction m_Player_CastSpell3;
    private readonly InputAction m_Player_CastSpell4;
    private readonly InputAction m_Player_CastSpell5;
    private readonly InputAction m_Player_CastSpell6;
    private readonly InputAction m_Player_CastSpell7;
    private readonly InputAction m_Player_CancelCast;
    private readonly InputAction m_Player_CastOnSelf;
    public struct PlayerActions
    {
        private @InputActions m_Wrapper;
        public PlayerActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movement => m_Wrapper.m_Player_Movement;
        public InputAction @Jump => m_Wrapper.m_Player_Jump;
        public InputAction @Interact => m_Wrapper.m_Player_Interact;
        public InputAction @Look => m_Wrapper.m_Player_Look;
        public InputAction @Zoom => m_Wrapper.m_Player_Zoom;
        public InputAction @SwapActionMap => m_Wrapper.m_Player_SwapActionMap;
        public InputAction @CastSpell1 => m_Wrapper.m_Player_CastSpell1;
        public InputAction @CastSpell2 => m_Wrapper.m_Player_CastSpell2;
        public InputAction @CastSpell3 => m_Wrapper.m_Player_CastSpell3;
        public InputAction @CastSpell4 => m_Wrapper.m_Player_CastSpell4;
        public InputAction @CastSpell5 => m_Wrapper.m_Player_CastSpell5;
        public InputAction @CastSpell6 => m_Wrapper.m_Player_CastSpell6;
        public InputAction @CastSpell7 => m_Wrapper.m_Player_CastSpell7;
        public InputAction @CancelCast => m_Wrapper.m_Player_CancelCast;
        public InputAction @CastOnSelf => m_Wrapper.m_Player_CastOnSelf;
        public InputActionMap Get() { return m_Wrapper.m_Player; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
        public void SetCallbacks(IPlayerActions instance)
        {
            if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
            {
                @Movement.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Movement.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnMovement;
                @Jump.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnJump;
                @Interact.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnInteract;
                @Look.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Look.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnLook;
                @Zoom.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZoom;
                @Zoom.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZoom;
                @Zoom.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnZoom;
                @SwapActionMap.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapActionMap;
                @SwapActionMap.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapActionMap;
                @SwapActionMap.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSwapActionMap;
                @CastSpell1.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell1;
                @CastSpell1.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell1;
                @CastSpell1.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell1;
                @CastSpell2.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell2;
                @CastSpell2.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell2;
                @CastSpell2.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell2;
                @CastSpell3.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell3;
                @CastSpell3.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell3;
                @CastSpell3.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell3;
                @CastSpell4.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell4;
                @CastSpell4.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell4;
                @CastSpell4.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell4;
                @CastSpell5.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell5;
                @CastSpell5.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell5;
                @CastSpell5.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell5;
                @CastSpell6.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell6;
                @CastSpell6.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell6;
                @CastSpell6.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell6;
                @CastSpell7.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell7;
                @CastSpell7.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell7;
                @CastSpell7.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastSpell7;
                @CancelCast.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCancelCast;
                @CancelCast.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCancelCast;
                @CancelCast.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCancelCast;
                @CastOnSelf.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastOnSelf;
                @CastOnSelf.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastOnSelf;
                @CastOnSelf.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnCastOnSelf;
            }
            m_Wrapper.m_PlayerActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movement.started += instance.OnMovement;
                @Movement.performed += instance.OnMovement;
                @Movement.canceled += instance.OnMovement;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Look.started += instance.OnLook;
                @Look.performed += instance.OnLook;
                @Look.canceled += instance.OnLook;
                @Zoom.started += instance.OnZoom;
                @Zoom.performed += instance.OnZoom;
                @Zoom.canceled += instance.OnZoom;
                @SwapActionMap.started += instance.OnSwapActionMap;
                @SwapActionMap.performed += instance.OnSwapActionMap;
                @SwapActionMap.canceled += instance.OnSwapActionMap;
                @CastSpell1.started += instance.OnCastSpell1;
                @CastSpell1.performed += instance.OnCastSpell1;
                @CastSpell1.canceled += instance.OnCastSpell1;
                @CastSpell2.started += instance.OnCastSpell2;
                @CastSpell2.performed += instance.OnCastSpell2;
                @CastSpell2.canceled += instance.OnCastSpell2;
                @CastSpell3.started += instance.OnCastSpell3;
                @CastSpell3.performed += instance.OnCastSpell3;
                @CastSpell3.canceled += instance.OnCastSpell3;
                @CastSpell4.started += instance.OnCastSpell4;
                @CastSpell4.performed += instance.OnCastSpell4;
                @CastSpell4.canceled += instance.OnCastSpell4;
                @CastSpell5.started += instance.OnCastSpell5;
                @CastSpell5.performed += instance.OnCastSpell5;
                @CastSpell5.canceled += instance.OnCastSpell5;
                @CastSpell6.started += instance.OnCastSpell6;
                @CastSpell6.performed += instance.OnCastSpell6;
                @CastSpell6.canceled += instance.OnCastSpell6;
                @CastSpell7.started += instance.OnCastSpell7;
                @CastSpell7.performed += instance.OnCastSpell7;
                @CastSpell7.canceled += instance.OnCastSpell7;
                @CancelCast.started += instance.OnCancelCast;
                @CancelCast.performed += instance.OnCancelCast;
                @CancelCast.canceled += instance.OnCancelCast;
                @CastOnSelf.started += instance.OnCastOnSelf;
                @CastOnSelf.performed += instance.OnCastOnSelf;
                @CastOnSelf.canceled += instance.OnCastOnSelf;
            }
        }
    }
    public PlayerActions @Player => new PlayerActions(this);

    // User Interface
    private readonly InputActionMap m_UserInterface;
    private IUserInterfaceActions m_UserInterfaceActionsCallbackInterface;
    private readonly InputAction m_UserInterface_SwapActionMap;
    private readonly InputAction m_UserInterface_CastOnSelf;
    private readonly InputAction m_UserInterface_MoveCursor;
    public struct UserInterfaceActions
    {
        private @InputActions m_Wrapper;
        public UserInterfaceActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @SwapActionMap => m_Wrapper.m_UserInterface_SwapActionMap;
        public InputAction @CastOnSelf => m_Wrapper.m_UserInterface_CastOnSelf;
        public InputAction @MoveCursor => m_Wrapper.m_UserInterface_MoveCursor;
        public InputActionMap Get() { return m_Wrapper.m_UserInterface; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(UserInterfaceActions set) { return set.Get(); }
        public void SetCallbacks(IUserInterfaceActions instance)
        {
            if (m_Wrapper.m_UserInterfaceActionsCallbackInterface != null)
            {
                @SwapActionMap.started -= m_Wrapper.m_UserInterfaceActionsCallbackInterface.OnSwapActionMap;
                @SwapActionMap.performed -= m_Wrapper.m_UserInterfaceActionsCallbackInterface.OnSwapActionMap;
                @SwapActionMap.canceled -= m_Wrapper.m_UserInterfaceActionsCallbackInterface.OnSwapActionMap;
                @CastOnSelf.started -= m_Wrapper.m_UserInterfaceActionsCallbackInterface.OnCastOnSelf;
                @CastOnSelf.performed -= m_Wrapper.m_UserInterfaceActionsCallbackInterface.OnCastOnSelf;
                @CastOnSelf.canceled -= m_Wrapper.m_UserInterfaceActionsCallbackInterface.OnCastOnSelf;
                @MoveCursor.started -= m_Wrapper.m_UserInterfaceActionsCallbackInterface.OnMoveCursor;
                @MoveCursor.performed -= m_Wrapper.m_UserInterfaceActionsCallbackInterface.OnMoveCursor;
                @MoveCursor.canceled -= m_Wrapper.m_UserInterfaceActionsCallbackInterface.OnMoveCursor;
            }
            m_Wrapper.m_UserInterfaceActionsCallbackInterface = instance;
            if (instance != null)
            {
                @SwapActionMap.started += instance.OnSwapActionMap;
                @SwapActionMap.performed += instance.OnSwapActionMap;
                @SwapActionMap.canceled += instance.OnSwapActionMap;
                @CastOnSelf.started += instance.OnCastOnSelf;
                @CastOnSelf.performed += instance.OnCastOnSelf;
                @CastOnSelf.canceled += instance.OnCastOnSelf;
                @MoveCursor.started += instance.OnMoveCursor;
                @MoveCursor.performed += instance.OnMoveCursor;
                @MoveCursor.canceled += instance.OnMoveCursor;
            }
        }
    }
    public UserInterfaceActions @UserInterface => new UserInterfaceActions(this);

    // PopUp
    private readonly InputActionMap m_PopUp;
    private IPopUpActions m_PopUpActionsCallbackInterface;
    private readonly InputAction m_PopUp_Cancel;
    private readonly InputAction m_PopUp_CastOnSelf;
    private readonly InputAction m_PopUp_MoveCursor;
    public struct PopUpActions
    {
        private @InputActions m_Wrapper;
        public PopUpActions(@InputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Cancel => m_Wrapper.m_PopUp_Cancel;
        public InputAction @CastOnSelf => m_Wrapper.m_PopUp_CastOnSelf;
        public InputAction @MoveCursor => m_Wrapper.m_PopUp_MoveCursor;
        public InputActionMap Get() { return m_Wrapper.m_PopUp; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PopUpActions set) { return set.Get(); }
        public void SetCallbacks(IPopUpActions instance)
        {
            if (m_Wrapper.m_PopUpActionsCallbackInterface != null)
            {
                @Cancel.started -= m_Wrapper.m_PopUpActionsCallbackInterface.OnCancel;
                @Cancel.performed -= m_Wrapper.m_PopUpActionsCallbackInterface.OnCancel;
                @Cancel.canceled -= m_Wrapper.m_PopUpActionsCallbackInterface.OnCancel;
                @CastOnSelf.started -= m_Wrapper.m_PopUpActionsCallbackInterface.OnCastOnSelf;
                @CastOnSelf.performed -= m_Wrapper.m_PopUpActionsCallbackInterface.OnCastOnSelf;
                @CastOnSelf.canceled -= m_Wrapper.m_PopUpActionsCallbackInterface.OnCastOnSelf;
                @MoveCursor.started -= m_Wrapper.m_PopUpActionsCallbackInterface.OnMoveCursor;
                @MoveCursor.performed -= m_Wrapper.m_PopUpActionsCallbackInterface.OnMoveCursor;
                @MoveCursor.canceled -= m_Wrapper.m_PopUpActionsCallbackInterface.OnMoveCursor;
            }
            m_Wrapper.m_PopUpActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Cancel.started += instance.OnCancel;
                @Cancel.performed += instance.OnCancel;
                @Cancel.canceled += instance.OnCancel;
                @CastOnSelf.started += instance.OnCastOnSelf;
                @CastOnSelf.performed += instance.OnCastOnSelf;
                @CastOnSelf.canceled += instance.OnCastOnSelf;
                @MoveCursor.started += instance.OnMoveCursor;
                @MoveCursor.performed += instance.OnMoveCursor;
                @MoveCursor.canceled += instance.OnMoveCursor;
            }
        }
    }
    public PopUpActions @PopUp => new PopUpActions(this);
    private int m_BaseControlSchemeSchemeIndex = -1;
    public InputControlScheme BaseControlSchemeScheme
    {
        get
        {
            if (m_BaseControlSchemeSchemeIndex == -1) m_BaseControlSchemeSchemeIndex = asset.FindControlSchemeIndex("BaseControlScheme");
            return asset.controlSchemes[m_BaseControlSchemeSchemeIndex];
        }
    }
    public interface IPlayerActions
    {
        void OnMovement(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnLook(InputAction.CallbackContext context);
        void OnZoom(InputAction.CallbackContext context);
        void OnSwapActionMap(InputAction.CallbackContext context);
        void OnCastSpell1(InputAction.CallbackContext context);
        void OnCastSpell2(InputAction.CallbackContext context);
        void OnCastSpell3(InputAction.CallbackContext context);
        void OnCastSpell4(InputAction.CallbackContext context);
        void OnCastSpell5(InputAction.CallbackContext context);
        void OnCastSpell6(InputAction.CallbackContext context);
        void OnCastSpell7(InputAction.CallbackContext context);
        void OnCancelCast(InputAction.CallbackContext context);
        void OnCastOnSelf(InputAction.CallbackContext context);
    }
    public interface IUserInterfaceActions
    {
        void OnSwapActionMap(InputAction.CallbackContext context);
        void OnCastOnSelf(InputAction.CallbackContext context);
        void OnMoveCursor(InputAction.CallbackContext context);
    }
    public interface IPopUpActions
    {
        void OnCancel(InputAction.CallbackContext context);
        void OnCastOnSelf(InputAction.CallbackContext context);
        void OnMoveCursor(InputAction.CallbackContext context);
    }
}
