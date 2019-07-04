Imports Microsoft.VisualBasic

Public Enum enumRecordType
  TechnicalOffer = 1
  RevisedOffer = 2
  RequestCommercialOffer = 3
  CommercialOffer = 4
  Communication = 5
End Enum
Public Enum enumTSStates
  Created = 1
  TechnicalSpecificationReleased = 2
  EnquiryInProgress = 3
  AllOfferReceived = 4
  CommercialofferFinalized = 5
  Acrchived = 6
End Enum
Public Enum enumEnquiryStates
  EnquiryCreated = 1
  EnquiryRaised = 2
  OfferReceived = 3
  CommercialNegotiationCompleted = 4
End Enum
Public Enum enumOfferStates
  Created = 1
  Submitted = 2
  OfferReceived = 3
  UnderEvaluation = 4
  Superseded = 5
  CommentSubmitted = 6
  TechnicallyCleared = 7
  ClosedByBuyer = 8
End Enum
Public Enum enumTSTypes
  Boughtout = 1
  Package = 2
  SelfEngineered = 3
End Enum
Public Enum enumERPStates
  Submitted = 1
  DocumentLinked = 2
  UnderEvaluation = 3
  CommentSubmitted = 4
  TechnicallyCleared = 5
  TransmittalIssued = 6
  Superseded = 7
  Closed = 8
End Enum